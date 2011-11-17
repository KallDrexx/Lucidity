namespace Lucidity.WinForms
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStoreOptions = new System.Windows.Forms.Button();
            this.btnParserOptions = new System.Windows.Forms.Button();
            this.btnParseLog = new System.Windows.Forms.Button();
            this.btnBrowseLogSource = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStores = new System.Windows.Forms.ComboBox();
            this.cmbParsers = new System.Windows.Forms.ComboBox();
            this.txtLogSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.grvResults = new System.Windows.Forms.DataGridView();
            this.grpFiltering = new System.Windows.Forms.GroupBox();
            this.btnEditFilter = new System.Windows.Forms.Button();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResults)).BeginInit();
            this.grpFiltering.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnStoreOptions);
            this.groupBox1.Controls.Add(this.btnParserOptions);
            this.groupBox1.Controls.Add(this.btnParseLog);
            this.groupBox1.Controls.Add(this.btnBrowseLogSource);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbStores);
            this.groupBox1.Controls.Add(this.cmbParsers);
            this.groupBox1.Controls.Add(this.txtLogSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // btnStoreOptions
            // 
            this.btnStoreOptions.Location = new System.Drawing.Point(441, 80);
            this.btnStoreOptions.Name = "btnStoreOptions";
            this.btnStoreOptions.Size = new System.Drawing.Size(75, 23);
            this.btnStoreOptions.TabIndex = 6;
            this.btnStoreOptions.Text = "Options";
            this.btnStoreOptions.UseVisualStyleBackColor = true;
            this.btnStoreOptions.Click += new System.EventHandler(this.btnStoreOptions_Click);
            // 
            // btnParserOptions
            // 
            this.btnParserOptions.Location = new System.Drawing.Point(441, 52);
            this.btnParserOptions.Name = "btnParserOptions";
            this.btnParserOptions.Size = new System.Drawing.Size(75, 23);
            this.btnParserOptions.TabIndex = 4;
            this.btnParserOptions.Text = "Options";
            this.btnParserOptions.UseVisualStyleBackColor = true;
            this.btnParserOptions.Click += new System.EventHandler(this.btnParserOptions_Click);
            // 
            // btnParseLog
            // 
            this.btnParseLog.Location = new System.Drawing.Point(77, 107);
            this.btnParseLog.Name = "btnParseLog";
            this.btnParseLog.Size = new System.Drawing.Size(75, 23);
            this.btnParseLog.TabIndex = 7;
            this.btnParseLog.Text = "Parse Logs";
            this.btnParseLog.UseVisualStyleBackColor = true;
            this.btnParseLog.Click += new System.EventHandler(this.btnParseLog_Click);
            // 
            // btnBrowseLogSource
            // 
            this.btnBrowseLogSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseLogSource.Location = new System.Drawing.Point(441, 23);
            this.btnBrowseLogSource.Name = "btnBrowseLogSource";
            this.btnBrowseLogSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLogSource.TabIndex = 2;
            this.btnBrowseLogSource.Text = "Browse";
            this.btnBrowseLogSource.UseVisualStyleBackColor = true;
            this.btnBrowseLogSource.Click += new System.EventHandler(this.btnBrowseLogSource_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Store:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parser:";
            // 
            // cmbStores
            // 
            this.cmbStores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStores.FormattingEnabled = true;
            this.cmbStores.Location = new System.Drawing.Point(77, 80);
            this.cmbStores.Name = "cmbStores";
            this.cmbStores.Size = new System.Drawing.Size(358, 21);
            this.cmbStores.TabIndex = 5;
            // 
            // cmbParsers
            // 
            this.cmbParsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbParsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParsers.FormattingEnabled = true;
            this.cmbParsers.Location = new System.Drawing.Point(77, 52);
            this.cmbParsers.Name = "cmbParsers";
            this.cmbParsers.Size = new System.Drawing.Size(358, 21);
            this.cmbParsers.TabIndex = 3;
            // 
            // txtLogSource
            // 
            this.txtLogSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogSource.Location = new System.Drawing.Point(77, 26);
            this.txtLogSource.Name = "txtLogSource";
            this.txtLogSource.Size = new System.Drawing.Size(358, 20);
            this.txtLogSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log Source:";
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.grvResults);
            this.grpResults.Location = new System.Drawing.Point(12, 301);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(522, 222);
            this.grpResults.TabIndex = 1;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // grvResults
            // 
            this.grvResults.AllowUserToAddRows = false;
            this.grvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvResults.Location = new System.Drawing.Point(3, 16);
            this.grvResults.Name = "grvResults";
            this.grvResults.ReadOnly = true;
            this.grvResults.Size = new System.Drawing.Size(516, 203);
            this.grvResults.TabIndex = 0;
            this.grvResults.VirtualMode = true;
            // 
            // grpFiltering
            // 
            this.grpFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltering.Controls.Add(this.btnEditFilter);
            this.grpFiltering.Controls.Add(this.btnRemoveFilter);
            this.grpFiltering.Controls.Add(this.btnAddFilter);
            this.grpFiltering.Controls.Add(this.lstFilters);
            this.grpFiltering.Location = new System.Drawing.Point(15, 164);
            this.grpFiltering.Name = "grpFiltering";
            this.grpFiltering.Size = new System.Drawing.Size(513, 131);
            this.grpFiltering.TabIndex = 1;
            this.grpFiltering.TabStop = false;
            this.grpFiltering.Text = "Filtering";
            // 
            // btnEditFilter
            // 
            this.btnEditFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditFilter.Enabled = false;
            this.btnEditFilter.Location = new System.Drawing.Point(432, 73);
            this.btnEditFilter.Name = "btnEditFilter";
            this.btnEditFilter.Size = new System.Drawing.Size(75, 23);
            this.btnEditFilter.TabIndex = 3;
            this.btnEditFilter.Text = "Edit";
            this.btnEditFilter.UseVisualStyleBackColor = true;
            this.btnEditFilter.Click += new System.EventHandler(this.btnEditFilter_Click);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFilter.Enabled = false;
            this.btnRemoveFilter.Location = new System.Drawing.Point(432, 102);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFilter.TabIndex = 2;
            this.btnRemoveFilter.Text = "Remove";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFilter.Location = new System.Drawing.Point(432, 19);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddFilter.TabIndex = 1;
            this.btnAddFilter.Text = "Add";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // lstFilters
            // 
            this.lstFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.Location = new System.Drawing.Point(6, 17);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(420, 108);
            this.lstFilters.TabIndex = 0;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 535);
            this.Controls.Add(this.grpFiltering);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.groupBox1);
            this.Name = "fmMain";
            this.Text = "Lucidity - Log Analysis";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvResults)).EndInit();
            this.grpFiltering.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseLogSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStores;
        private System.Windows.Forms.ComboBox cmbParsers;
        private System.Windows.Forms.TextBox txtLogSource;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.DataGridView grvResults;
        private System.Windows.Forms.Button btnParseLog;
        private System.Windows.Forms.GroupBox grpFiltering;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Button btnEditFilter;
        private System.Windows.Forms.Button btnParserOptions;
        private System.Windows.Forms.Button btnStoreOptions;
    }
}