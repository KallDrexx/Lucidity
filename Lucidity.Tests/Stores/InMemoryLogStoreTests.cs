using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Data;
using Lucidity.Engine.Stores;

namespace Lucidity.Tests.Stores
{
    [TestClass]
    public class InMemoryLogStoreTests
    {
        [TestMethod]
        public void Can_Store_And_Retrieve_Log_Records()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            // Act
            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);
            IList<LogRecord> result = store.GetFilteredRecords(null);

            // Verify
            Assert.IsNotNull(result, "Store returned a null result");
            Assert.AreEqual(2, result.Count, "Store returned an incorrect number of records");
            Assert.AreEqual(record1, result[0], "First record returned by the store was incorrect");
            Assert.AreEqual(record2, result[1], "Second record returned by the store was incorect");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Inclusive_Text()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            record1.Fields.Add(new LogField { FieldName = "f1", StringValue = "Pass" });
            record1.Fields.Add(new LogField { FieldName = "f2", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f1", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f2", StringValue = "Pass" });

            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] { 
                    new LogFilter { FilteredFieldName = "f2", TextFilter = "Pass", FilterType = LogFilterType.Text, ExclusiveFilter = false } });

            // Act
            var result = store.GetFilteredRecords(filter);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record2, result[0], "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Exclusive_Text()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            record1.Fields.Add(new LogField { FieldName = "f1", StringValue = "Pass" });
            record1.Fields.Add(new LogField { FieldName = "f2", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f1", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f2", StringValue = "Pass" });

            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] { 
                    new LogFilter { FilteredFieldName = "f2", TextFilter = "Pass", FilterType = LogFilterType.Text, ExclusiveFilter = true } });

            // Act
            var result = store.GetFilteredRecords(filter);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record1, result[0], "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Inclusive_Start_Date()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });

            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] 
                { 
                    new LogFilter 
                    { 
                        FilteredFieldName = "f2", 
                        StartDate = new DateTime(2011, 2, 1),
                        FilterType = LogFilterType.Date, 
                        ExclusiveFilter = false 
                    } 
                }
            );

            // Act
            var result = store.GetFilteredRecords(filter);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record2, result[0], "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Exclusive_Start_Date()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });

            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] 
                { 
                    new LogFilter 
                    { 
                        FilteredFieldName = "f2", 
                        StartDate = new DateTime(2011, 2, 1),
                        FilterType = LogFilterType.Date, 
                        ExclusiveFilter = true 
                    } 
                }
            );

            // Act
            var result = store.GetFilteredRecords(filter);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record1, result[0], "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Inclusive_Date_Range()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });

            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] 
                { 
                    new LogFilter 
                    { 
                        FilteredFieldName = "f2", 
                        StartDate = new DateTime(2010, 12, 1),
                        EndDate = new DateTime(2011, 2, 1),
                        FilterType = LogFilterType.Date, 
                        ExclusiveFilter = false 
                    } 
                }
            );

            // Act
            var result = store.GetFilteredRecords(filter);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record2, result[0], "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Exclusive_Date_Range()
        {
            // Setup
            var store = new InMemoryLogStore();

            var record1 = new LogRecord();
            var record2 = new LogRecord();

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });

            store.StoreLogRecord(record1);
            store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] 
                { 
                    new LogFilter 
                    { 
                        FilteredFieldName = "f2", 
                        StartDate = new DateTime(2010, 12, 1),
                        EndDate = new DateTime(2011, 2, 1),
                        FilterType = LogFilterType.Date, 
                        ExclusiveFilter = true 
                    } 
                }
            );

            // Act
            var result = store.GetFilteredRecords(filter);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record1, result[0], "Incorrect record returned");
        }

        [TestMethod]
        public void Can_Get_List_Of_Field_Names()
        {
            // Setup
            var store = new InMemoryLogStore();
            store.StoreLogRecord(new LogRecord
            {
                Fields = new List<LogField>
                {
                    new LogField { FieldName = "f1" },
                    new LogField { FieldName = "f2" }
                }
            });

            store.StoreLogRecord(new LogRecord
            {
                Fields = new List<LogField>
                {
                    new LogField { FieldName = "f2" },
                    new LogField { FieldName = "f3" }
                }
            });

            // Act
            IList<string> results = store.GetLogFieldNames();

            // Verify
            Assert.IsNotNull(results, "Null list was returned");
            Assert.AreEqual(3, results.Count, "List contained an incorrect number of elements");
            Assert.IsTrue(results.Contains("f1"), "List did not contain the field name 'f1'");
            Assert.IsTrue(results.Contains("f2"), "List did not contain the field name 'f2'");
            Assert.IsTrue(results.Contains("f3"), "List did not contain the field name 'f3'");
        }

        [TestMethod]
        public void Inclusive_Text_Filter_Is_Case_Insensitive()
        {
            // Setup
            var store = new InMemoryLogStore();
            store.StoreLogRecord(new LogRecord { Fields = new List<LogField> { new LogField { StringValue = "ABC", FieldName = "field" }}});
            var filter = new List<LogFilter> { new LogFilter 
            { 
                FilteredFieldName = "field", 
                FilterType = LogFilterType.Text, 
                ExclusiveFilter = false,
                TextFilter = "abc"
            }};

            // Act
            IList<LogRecord> results = store.GetFilteredRecords(filter);

            // Verify
            Assert.IsNotNull(results, "Store returned a null result");
            Assert.AreEqual(1, results.Count, "Incorrect number of recods returned");
        }

        [TestMethod]
        public void Exclusive_Text_Filter_Is_Case_Insensitive()
        {
            // Setup
            var store = new InMemoryLogStore();
            store.StoreLogRecord(new LogRecord { Fields = new List<LogField> { new LogField { StringValue = "ABC", FieldName = "field" } } });
            var filter = new List<LogFilter> { new LogFilter 
            { 
                FilteredFieldName = "field", 
                FilterType = LogFilterType.Text, 
                ExclusiveFilter = true,
                TextFilter = "abc"
            }};

            // Act
            IList<LogRecord> results = store.GetFilteredRecords(filter);

            // Verify
            Assert.IsNotNull(results, "Store returned a null result");
            Assert.AreEqual(0, results.Count, "Incorrect number of recods returned");
        }
    }
}
