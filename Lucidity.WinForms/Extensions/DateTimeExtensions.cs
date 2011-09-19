using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lucidity.WinForms.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToDatePickerValidDateTime(this DateTime dt, DateTimePicker picker)
        {
            if (picker == null)
                return dt;

            if (dt < picker.MinDate)
                return picker.MinDate;
            else if (dt > picker.MaxDate)
                return picker.MaxDate;

            return dt;
        }
    }
}
