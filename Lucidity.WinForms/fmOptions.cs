using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucidity.Engine.Options;

namespace Lucidity.WinForms
{
    public partial class fmOptions : Form
    {
        public fmOptions(IList<LucidityOption> options)
        {
            InitializeComponent();

            _optionList = options;
        }

        private void fmOptions_Load(object sender, EventArgs e)
        {
            // Create all the controls based on the options of the options class
            if (_optionList.Count == 0)
            {
                var lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = "There are no options available to set";

                tblLayout.Controls.Add(lbl, 0, 0);
                return;
            }

            for (int x = 0; x < _optionList.Count; x++)
            {
                // Create the text label
                var lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = _optionList[x].Name + ":";

                // Create the input control
                Control control = CreateInputControl(_optionList[x]);

                // Add the controls into the table
                tblLayout.Controls.Add(lbl, 0, x);
                tblLayout.Controls.Add(control, 1, x);
            }
        }

        private Control CreateInputControl(LucidityOption option)
        {
            Control control;

            // Create an input control for the option based on the option type
            switch (option.OptionType)
            {
                case SupportedOptionTypes.String:
                    control = new TextBox();
                    (control as TextBox).Text = Convert.ToString(option.Value);
                    control.Width = 300;
                    (control as TextBox).TextChanged += (s, e) => { option.Value = (s as TextBox).Text; };
                    break;

                case SupportedOptionTypes.Bool:
                    control = new CheckBox();
                    (control as CheckBox).Checked = Convert.ToBoolean(option.Value);
                    (control as CheckBox).CheckStateChanged += (s, e) => { option.Value = (s as CheckBox).Checked; };
                    break;

                case SupportedOptionTypes.Integer:
                    control = new NumericUpDown();
                    (control as NumericUpDown).Value = Convert.ToInt32(option.Value);
                    (control as NumericUpDown).ValueChanged += (s, e) => { option.Value = Convert.ToInt32((s as NumericUpDown).Value); };
                    break;

                case SupportedOptionTypes.Decimal:
                    control = new NumericUpDown();
                    (control as NumericUpDown).DecimalPlaces = 2;
                    (control as NumericUpDown).Value = Convert.ToDecimal(option.Value);
                    (control as NumericUpDown).ValueChanged += (s, e) => { option.Value = (s as NumericUpDown).Value; };
                    break;

                default:
                    MessageBox.Show(string.Format("Cannot create an input control for the option type of {0}", option.OptionType.ToString()));
                    control = null;
                    break;
            }

            return control;
        }

        private IList<LucidityOption> _optionList;
    }
}
