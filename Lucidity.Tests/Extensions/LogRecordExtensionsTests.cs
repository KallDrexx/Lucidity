using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Data;
using Lucidity.WinForms.Extensions;
using System.Data;

namespace Lucidity.Tests.Extensions
{
    [TestClass]
    public class LogRecordExtensionsTests
    {
        [TestMethod]
        public void Can_Convert_Log_Record_List_To_DataTable()
        {
            // Setup
            var logs = new List<LogRecord>
            {
                new LogRecord
                {
                    Fields = new List<LogField>
                    {
                        new LogField { FieldName = "col 1", StringValue = "val 1" },
                        new LogField { FieldName = "col 2", StringValue = "val 2" },
                        new LogField { FieldName = "col 3", StringValue = "val 3" }
                    }
                },

                new LogRecord
                {
                    Fields = new List<LogField>
                    {
                        new LogField { FieldName = "col 1", StringValue = "val 4" },
                        new LogField { FieldName = "col 2", StringValue = "val 5" },
                        new LogField { FieldName = "col 3", StringValue = "val 6" }
                    }
                }
            };

            // Act
            DataTable results = logs.ToDataTable();

            // Verify
            Assert.IsNotNull(results, "Resulting data table was null");

            Assert.AreEqual(3, results.Columns.Count, "Table had an incorrect number of columns");
            Assert.IsTrue(results.Columns.Contains("col 1"), "Table did not have a column named 'col 1'");
            Assert.IsTrue(results.Columns.Contains("col 2"), "Table did not have a column named 'col 1'");
            Assert.IsTrue(results.Columns.Contains("col 3"), "Table did not have a column named 'col 1'");

            Assert.AreEqual(2, results.Rows.Count, "Table had an incorrecct number of rows");
            Assert.AreEqual("val 1", results.Rows[0]["col 1"], "First row had an incorrect value for the col 1 column");
            Assert.AreEqual("val 2", results.Rows[0]["col 2"], "First row had an incorrect value for the col 2 column");
            Assert.AreEqual("val 3", results.Rows[0]["col 3"], "First row had an incorrect value for the col 3 column");
            Assert.AreEqual("val 4", results.Rows[1]["col 1"], "Second row had an incorrect value for the col 1 column");
            Assert.AreEqual("val 5", results.Rows[1]["col 2"], "Second row had an incorrect value for the col 2 column");
            Assert.AreEqual("val 6", results.Rows[1]["col 3"], "Second row had an incorrect value for the col 3 column");
        }

        [TestMethod]
        public void Null_Log_Record_List_Returns_Empty_DataTable()
        {
            // Setup
            IList<LogRecord> logs = null;

            // Act
            DataTable table = logs.ToDataTable();

            // Verify
            Assert.IsNotNull(table, "Null data table returned");
            Assert.AreEqual(0, table.Columns.Count, "Table had an incorrect column count");
            Assert.AreEqual(0, table.Rows.Count, "Table had an incorrect row count");
        }
    }
}
