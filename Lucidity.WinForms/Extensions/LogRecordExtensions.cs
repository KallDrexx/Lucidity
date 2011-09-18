using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;
using System.Data;

namespace Lucidity.WinForms.Extensions
{
    public static class LogRecordExtensions
    {
        /// <summary>
        /// Converts a list of log records into a data table
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this IList<LogRecord> records)
        {
            if (records == null)
                return new DataTable();

            var table = new DataTable();

            foreach (var record in records)
            {
                //Make sure the data table has the columns for all the fields
                foreach (var field in record.Fields)
                    if (!table.Columns.Contains(field.FieldName))
                        table.Columns.Add(field.FieldName);

                // Create the data row for the recod
                var row = table.NewRow();
                foreach (var field in record.Fields)
                    row[field.FieldName] = field.StringValue;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
