namespace Lucidity.WinForms
{
    partial class fmEditFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDateFilter = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDateFilter = new System.Windows.Forms.DateTimePicker();
            this.cmbFieldNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkExclusiveFilter = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFilterString = new System.Windows.Forms.Label();
            this.btnSetStartDateNow = new System.Windows.Forms.Button();
            this.btnSetEndDateNow = new System.Windows.Forms.Button();
            this.grpText = new System.Windows.Forms.GroupBox();
            this.grpDate = new System.Windows.Forms.GroupBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.grpText.SuspendLayout();
            this.grpDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Type:";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "Text",
            "Date"});
            this.cmbFilterType.Location = new System.Drawing.Point(74, 57);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(220, 21);
            this.cmbFilterType.TabIndex = 1;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // txtFilterText
            // 
            this.txtFilterText.Location = new System.Drawing.Point(65, 19);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(214, 20);
            this.txtFilterText.TabIndex = 4;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Containing:";
            // 
            // dtpStartDateFilter
            // 
            this.dtpStartDateFilter.CustomFormat = "";
            this.dtpStartDateFilter.Location = new System.Drawing.Point(65, 18);
            this.dtpStartDateFilter.Name = "dtpStartDateFilter";
            this.dtpStartDateFilter.Size = new System.Drawing.Size(188, 20);
            this.dtpStartDateFilter.TabIndex = 5;
            this.dtpStartDateFilter.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDateFilter.ValueChanged += new System.EventHandler(this.StartDateFilter_ValueChanged);
            // 
            // dtpEndDateFilter
            // 
            this.dtpEndDateFilter.CustomFormat = "";
            this.dtpEndDateFilter.Location = new System.Drawing.Point(65, 70);
            this.dtpEndDateFilter.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtpEndDateFilter.Name = "dtpEndDateFilter";
            this.dtpEndDateFilter.Size = new System.Drawing.Size(188, 20);
            this.dtpEndDateFilter.TabIndex = 8;
            this.dtpEndDateFilter.Value = new System.DateTime(2109, 12, 31, 0, 0, 0, 0);
            this.dtpEndDateFilter.ValueChanged += new System.EventHandler(this.EndDateFilter_ValueChanged);
            // 
            // cmbFieldNames
            // 
            this.cmbFieldNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFieldNames.FormattingEnabled = true;
            this.cmbFieldNames.Location = new System.Drawing.Point(74, 84);
            this.cmbFieldNames.Name = "cmbFieldNames";
            this.cmbFieldNames.Size = new System.Drawing.Size(220, 21);
            this.cmbFieldNames.TabIndex = 2;
            this.cmbFieldNames.SelectedIndexChanged += new System.EventHandler(this.cmbFieldNames_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Field Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Between:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "And:";
            // 
            // chkExclusiveFilter
            // 
            this.chkExclusiveFilter.AutoSize = true;
            this.chkExclusiveFilter.Location = new System.Drawing.Point(74, 111);
            this.chkExclusiveFilter.Name = "chkExclusiveFilter";
            this.chkExclusiveFilter.Size = new System.Drawing.Size(96, 17);
            this.chkExclusiveFilter.TabIndex = 3;
            this.chkExclusiveFilter.Text = "Exclusive Filter";
            this.chkExclusiveFilter.UseVisualStyleBackColor = true;
            this.chkExclusiveFilter.CheckedChanged += new System.EventHandler(this.chkExclusiveFilter_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(254, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save Filter";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFilterString
            // 
            this.lblFilterString.AutoSize = true;
            this.lblFilterString.Location = new System.Drawing.Point(28, 9);
            this.lblFilterString.Name = "lblFilterString";
            this.lblFilterString.Size = new System.Drawing.Size(0, 13);
            this.lblFilterString.TabIndex = 13;
            // 
            // btnSetStartDateNow
            // 
            this.btnSetStartDateNow.Location = new System.Drawing.Point(264, 19);
            this.btnSetStartDateNow.Name = "btnSetStartDateNow";
            this.btnSetStartDateNow.Size = new System.Drawing.Size(50, 23);
            this.btnSetStartDateNow.TabIndex = 7;
            this.btnSetStartDateNow.Text = "Now";
            this.btnSetStartDateNow.UseVisualStyleBackColor = true;
            this.btnSetStartDateNow.Click += new System.EventHandler(this.btnSetStartDateNow_Click);
            // 
            // btnSetEndDateNow
            // 
            this.btnSetEndDateNow.Location = new System.Drawing.Point(264, 70);
            this.btnSetEndDateNow.Name = "btnSetEndDateNow";
            this.btnSetEndDateNow.Size = new System.Drawing.Size(50, 23);
            this.btnSetEndDateNow.TabIndex = 10;
            this.btnSetEndDateNow.Text = "Now";
            this.btnSetEndDateNow.UseVisualStyleBackColor = true;
            this.btnSetEndDateNow.Click += new System.EventHandler(this.btnSetEndDateNow_Click);
            // 
            // grpText
            // 
            this.grpText.Controls.Add(this.txtFilterText);
            this.grpText.Controls.Add(this.label2);
            this.grpText.Location = new System.Drawing.Point(9, 134);
            this.grpText.Name = "grpText";
            this.grpText.Size = new System.Drawing.Size(320, 52);
            this.grpText.TabIndex = 16;
            this.grpText.TabStop = false;
            this.grpText.Text = "Text Filters";
            // 
            // grpDate
            // 
            this.grpDate.Controls.Add(this.dtpEndTime);
            this.grpDate.Controls.Add(this.dtpStartTime);
            this.grpDate.Controls.Add(this.dtpStartDateFilter);
            this.grpDate.Controls.Add(this.dtpEndDateFilter);
            this.grpDate.Controls.Add(this.btnSetEndDateNow);
            this.grpDate.Controls.Add(this.label5);
            this.grpDate.Controls.Add(this.btnSetStartDateNow);
            this.grpDate.Controls.Add(this.label6);
            this.grpDate.Location = new System.Drawing.Point(9, 192);
            this.grpDate.Name = "grpDate";
            this.grpDate.Size = new System.Drawing.Size(320, 129);
            this.grpDate.TabIndex = 17;
            this.grpDate.TabStop = false;
            this.grpDate.Text = "Date Filters";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(65, 99);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(113, 20);
            this.dtpEndTime.TabIndex = 9;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.EndDateFilter_ValueChanged);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(65, 44);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(113, 20);
            this.dtpStartTime.TabIndex = 6;
            this.dtpStartTime.TabStop = false;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.StartDateFilter_ValueChanged);
            // 
            // fmEditFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 362);
            this.Controls.Add(this.grpDate);
            this.Controls.Add(this.grpText);
            this.Controls.Add(this.lblFilterString);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkExclusiveFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbFieldNames);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.label1);
            this.Name = "fmEditFilter";
            this.Text = "Edit Filter";
            this.Load += new System.EventHandler(this.fmEditFilter_Load);
            this.grpText.ResumeLayout(false);
            this.grpText.PerformLayout();
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDateFilter;
        private System.Windows.Forms.DateTimePicker dtpEndDateFilter;
        private System.Windows.Forms.ComboBox cmbFieldNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkExclusiveFilter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFilterString;
        private System.Windows.Forms.Button btnSetStartDateNow;
        private System.Windows.Forms.Button btnSetEndDateNow;
        private System.Windows.Forms.GroupBox grpText;
        private System.Windows.Forms.GroupBox grpDate;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
    }
}