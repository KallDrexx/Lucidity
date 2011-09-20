using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucidity.Engine.Data;
using Lucidity.WinForms.Extensions;

namespace Lucidity.WinForms
{
    public partial class fmEditFilter : Form
    {
        public fmEditFilter(LogFilter filter, IEnumerable<string> fieldNames)
        {
            Filter = filter ?? new LogFilter();
            _fieldNames = fieldNames;

            InitializeComponent();
        }

        #region Events

        private void fmEditFilter_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            cmbFieldNames.DataSource = _fieldNames;
            dtpStartDateFilter.Value = dtpStartDateFilter.MinDate;
            dtpEndDateFilter.Value = dtpEndDateFilter.MaxDate;

            // Setup the filter label to grow and word wrap
            lblFilterString.AutoSize = true;
            lblFilterString.MaximumSize = new Size(this.Width - lblFilterString.Left - 20, 0);

            // Set the values to the current filter's data
            cmbFilterType.SelectedItem = Filter.FilterType == LogFilterType.Text ? "Text" : "Date";
            cmbFieldNames.SelectedItem = Filter.FilteredFieldName;
            dtpStartDateFilter.Value = Filter.StartDate.ToDatePickerValidDateTime(dtpStartDateFilter);
            dtpEndDateFilter.Value = Filter.EndDate.ToDatePickerValidDateTime(dtpEndDateFilter);
            txtFilterText.Text = Filter.TextFilter;
            chkExclusiveFilter.Checked = Filter.ExclusiveFilter;

            UpdateFilterLabel();

            _isLoading = false;
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // NOTE: This event still need to run even while loading

            if (cmbFilterType.SelectedItem == null)
                return;

            if ((string)cmbFilterType.SelectedItem == "Text")
            {
                Filter.FilterType = LogFilterType.Text;
                grpDate.Enabled = false;
                grpText.Enabled = true;
            }
            else if ((string)cmbFilterType.SelectedItem == "Date")
            {
                Filter.FilterType = LogFilterType.Date;
                grpDate.Enabled = true;
                grpText.Enabled = false;
            }

            UpdateFilterLabel();
        }

        private void btnSetStartDateNow_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            dtpStartDateFilter.Value = DateTime.Now;
        }

        private void btnSetEndDateNow_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            dtpEndDateFilter.Value = DateTime.Now;
        }

        private void cmbFieldNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            if (cmbFieldNames.SelectedItem == null || (cmbFieldNames.SelectedItem as string) == null)
                return;

            Filter.FilteredFieldName = (string)cmbFieldNames.SelectedItem;
            UpdateFilterLabel();
        }

        private void chkExclusiveFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            if (chkExclusiveFilter.Checked)
                Filter.ExclusiveFilter = true;
            else
                Filter.ExclusiveFilter = false;

            UpdateFilterLabel();
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            Filter.TextFilter = txtFilterText.Text.Trim();
            UpdateFilterLabel();
        }

        private void dtpStartDateFilter_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            Filter.StartDate = dtpStartDateFilter.Value;
            UpdateFilterLabel();
        }

        private void dtpEndDateFilter_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            Filter.EndDate = dtpEndDateFilter.Value;
            UpdateFilterLabel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FilterIsValid())
                return;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Utility Method

        protected void UpdateFilterLabel()
        {
            lblFilterString.Text = Filter.ToString();
        }

        protected bool FilterIsValid()
        {
            string validationErrorCaption = "Filter Validation Error";

            // Make sure any required fields are filled in
            if (string.IsNullOrWhiteSpace(Filter.FilteredFieldName))
            {
                MessageBox.Show("A field name for the filter must be specified", validationErrorCaption);
                return false;
            }

            if (Filter.FilterType == LogFilterType.Text && string.IsNullOrWhiteSpace(Filter.TextFilter))
            {
                MessageBox.Show("When specifying a text filter, you must have text to filter by", validationErrorCaption);
                return false;
            }

            return true;
        }

        #endregion

        #region Properties and Variables

        public LogFilter Filter { get; protected set; }
        protected IEnumerable<string> _fieldNames;
        protected bool _isLoading;

        #endregion
    }
}
