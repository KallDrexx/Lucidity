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
            // Retrieve the list of log parser and stores and bind the combo boxes to it
            _parsers = LogParserUtils.GetAvailableLogParsers();
            _stores = LogStoreUtils.GetAvailableLogStores();

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
            var store = cmbStores.SelectedValue as ILogStore;
            parser.StoreRecordMethod = store.StoreLogRecord;
            store.Initialize();

            // Run the parser
            grvResults.Enabled = false;
            parser.ParseLog(txtLogSource.Text);
            grvResults.Enabled = true;

            MessageBox.Show("Log successfully parsed and stored");
        }

        #endregion

        #region Member Variables

        protected IList<ILogParser> _parsers;
        protected IList<ILogStore> _stores;

        #endregion

        #region Utility Methods

        private bool ValidParameters()
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

        #endregion
    }
}
