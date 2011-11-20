using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Stores;
using Lucidity.Engine.Utils;
using Lucidity.WinForms.Extensions;
using Lucidity.Engine.Data;

namespace Lucidity.WinForms
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        #region Events

        private void fmMain_Load(object sender, EventArgs e)
        {
            grpFiltering.Enabled = false;
            grpResults.Enabled = false;

            _filters = new BindingList<LogFilter>();
            _filters.ListChanged += this.FilterListChanged;
            lstFilters.DataSource = _filters;

            // Retrieve the list of log parsers and stores and bind the combo boxes to it
            var importer = new LucidityImporter();
            _parsers = importer.LogParsers;
            _stores = importer.LogStores;

            if (_parsers.Count == 0 || _stores.Count == 0)
            {
                string message = string.Empty;
                if (_parsers.Count == 0) { message += "No log parsers were found." + Environment.NewLine; }
                if (_stores.Count == 0) { message += "No log stores were found. " + Environment.NewLine; }

                btnParseLog.Enabled = false;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmbParsers.DataSource = _parsers.Select(x => new { @Type = x, Name = x.ParserName }).ToList();
            cmbParsers.DisplayMember = "Name";
            cmbParsers.ValueMember = "Type";

            cmbStores.DataSource = _stores.Select(x => new { @Type = x, Name = x.Name }).ToList();
            cmbStores.DisplayMember = "Name";
            cmbStores.ValueMember = "Type";
        }

        private void btnBrowseLogSource_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Select Log File";

            if (dlg.ShowDialog() == DialogResult.OK)
                txtLogSource.Text = dlg.FileName;
        }

        private void btnParseLog_Click(object sender, EventArgs e)
        {
            if (!ValidParameters())
                return;

            // Initialize and configure the parser and store
            var parser = cmbParsers.SelectedValue as ILogParser;
            _currentStore = cmbStores.SelectedValue as ILogStore;
            parser.StoreRecordMethod = _currentStore.StoreLogRecord;
            _currentStore.Initialize();

            // Run the parser and get the results
            grpResults.Enabled = false;
            grpFiltering.Enabled = false;

            _currentSessionId = parser.ParseLog(txtLogSource.Text);
            UpdateLogResults();
            _fieldNames = _currentStore.GetLogFieldNames(_currentSessionId);

            grpResults.Enabled = true;
            grpFiltering.Enabled = true;
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            var filterDlg = new fmEditFilter(new LogFilter(), _fieldNames);

            if (filterDlg.ShowDialog() == DialogResult.OK)
                _filters.Add(filterDlg.Filter);
        }

        private void btnEditFilter_Click(object sender, EventArgs e)
        {
            var filterDlg = new fmEditFilter(lstFilters.SelectedItem as LogFilter, _fieldNames);
            if (filterDlg.ShowDialog() == DialogResult.OK)
            {
                _filters.Remove(lstFilters.SelectedItem as LogFilter);
                _filters.Add(filterDlg.Filter);
            }
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            _filters.Remove(lstFilters.SelectedItem as LogFilter);
        }

        private void FilterListChanged(object sender, ListChangedEventArgs e)
        {
            // Check if the edit and remove list box buttons should be enabled or not
            if (_filters.Count == 0)
            {
                btnEditFilter.Enabled = false;
                btnRemoveFilter.Enabled = false;
            }

            else
            {
                btnEditFilter.Enabled = true;
                btnRemoveFilter.Enabled = true;
            }

            // Re-fetch results based on the list of filters
            UpdateLogResults();
        }

        private void btnParserOptions_Click(object sender, EventArgs e)
        {
            if (cmbParsers.SelectedItem == null)
                return;

            var fmOpts = new fmOptions((cmbParsers.SelectedValue as ILogParser).GetParserOptions().GetOptions());
            fmOpts.ShowDialog();
        }

        private void btnStoreOptions_Click(object sender, EventArgs e)
        {
            if (cmbStores.SelectedItem == null)
                return;

            var fmOpts = new fmOptions((cmbStores.SelectedValue as ILogStore).GetStoreOptions().GetOptions());
            fmOpts.ShowDialog();
        }

        private void grvResults_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            LogRecord record = null;

            // Check if this record for this row is cached
            if (_recordCache.ContainsKey(e.RowIndex))
            {
                record = _recordCache[e.RowIndex];
            }

            else
            {
                // Retrieve the record from the store
                var records = _currentStore.GetFilteredRecords(_filters, _currentSessionId, 1, e.RowIndex);
                if (records.Count > 0)
                {
                    record = records[0];

                    // Store the record in the cache
                    _recordCache.Add(e.RowIndex, record);
                }
            }

            if (record != null)
            {
                // Match the cell to the field
                string cellFieldName = grvResults.Columns[e.ColumnIndex].Name;
                if (record.Fields.Any(x => x.FieldName.Equals(cellFieldName, StringComparison.CurrentCultureIgnoreCase)))
                    e.Value = record.Fields.Where(x => x.FieldName.Equals(cellFieldName, StringComparison.CurrentCultureIgnoreCase)).Single().StringValue;
            }
        }

        #endregion

        #region Member Variables

        protected IList<ILogParser> _parsers;
        protected IList<ILogStore> _stores;
        protected Dictionary<int, LogRecord> _recordCache;

        protected IEnumerable<string> _fieldNames;
        protected BindingList<LogFilter> _filters;
        protected ILogStore _currentStore;
        protected Guid _currentSessionId;

        #endregion

        #region Utility Methods

        protected bool ValidParameters()
        {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(txtLogSource.Text))
            {
                MessageBox.Show("A log source must be specified", "Validation Error");
                return false;
            }

            if (cmbParsers.SelectedItem == null || cmbStores.SelectedItem == null)
            {
                MessageBox.Show("A parser and log store must be selected", "Validation Error");
                return false;
            }

            if ((cmbParsers.SelectedValue as ILogParser) == null)
            {
                MessageBox.Show("The selected parser is not a valid log parser", "Validation Error");
                return false;
            }

            if ((cmbStores.SelectedValue as ILogStore) == null)
            {
                MessageBox.Show("The selected parser is not a valid log parser", "Validation Error");
                return false;
            }

            return true;
        }

        protected void UpdateLogResults()
        {
            // Set the columns
            var fields = _currentStore.GetLogFieldNames(_currentSessionId);
            grvResults.Columns.Clear();
            foreach (var field in fields)
                grvResults.Columns.Add(field, field);

            // Set the number of rows
            var recordCount = _currentStore.GetTotalRecordCount(_filters, _currentSessionId);
            grvResults.RowCount = recordCount;

            // Reset the record cache
            _recordCache = new Dictionary<int, LogRecord>();
        }

        #endregion
    }
}
