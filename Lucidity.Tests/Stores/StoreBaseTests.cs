using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Stores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Data;
using Lucidity.Engine.Options;

namespace Lucidity.Tests.Stores
{
    /// <summary>
    /// All stores must pass these tests for log parsing to be consistent
    /// </summary>
    [TestClass]
    [Ignore]
    public abstract class StoreBaseTests
    {
        protected ILogStore _store;
        protected Type _expectedOptionsType;

        [TestMethod]
        public void Can_Store_And_Retrieve_Log_Records()
        {
            // Setup
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };
            _store.Initialize();

            // Act
            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);
            IList<LogRecord> result = _store.GetFilteredRecords(null, new Guid(), 2, 1);

            // Verify
            Assert.IsNotNull(result, "Store returned a null result");
            Assert.AreEqual(2, result.Count, "Store returned an incorrect number of records");
            Assert.AreEqual(record1.RecordNumber, result[0].RecordNumber, "First record returned by the store was incorrect");
            Assert.AreEqual(record2.RecordNumber, result[1].RecordNumber, "Second record returned by the store was incorect");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Inclusive_Text()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };

            record1.Fields.Add(new LogField { FieldName = "f1", StringValue = "Pass" });
            record1.Fields.Add(new LogField { FieldName = "f2", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f1", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f2", StringValue = "Pass" });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] { 
                    new LogFilter { FilteredFieldName = "f2", TextFilter = "Pass", FilterType = LogFilterType.Text, ExclusiveFilter = false } });

            // Act
            var result = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record2.RecordNumber, result[0].RecordNumber, "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Exclusive_Text()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };

            record1.Fields.Add(new LogField { FieldName = "f1", StringValue = "Pass" });
            record1.Fields.Add(new LogField { FieldName = "f2", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f1", StringValue = "Fail" });
            record2.Fields.Add(new LogField { FieldName = "f2", StringValue = "Pass" });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);

            var filter = new List<LogFilter>(
                new LogFilter[] { 
                    new LogFilter { FilteredFieldName = "f2", TextFilter = "Pass", FilterType = LogFilterType.Text, ExclusiveFilter = true } });

            // Act
            var result = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record1.RecordNumber, result[0].RecordNumber, "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Inclusive_Start_Date()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);

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
            var result = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record2.RecordNumber, result[0].RecordNumber, "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Exclusive_Start_Date()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);

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
            var result = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record1.RecordNumber, result[0].RecordNumber, "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Inclusive_Date_Range()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);

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
            var result = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record2.RecordNumber, result[0].RecordNumber, "Incorrect record returned");
        }

        [TestMethod]
        public void Store_Can_Filter_Records_By_Exclusive_Date_Range()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };

            record1.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 1, 1) });
            record1.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f1", DateValue = new DateTime(2011, 3, 1) });
            record2.Fields.Add(new LogField { FieldName = "f2", DateValue = new DateTime(2011, 1, 1) });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);

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
            var result = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.AreEqual(1, result.Count, "Incorrect number of records returned");
            Assert.AreEqual(record1.RecordNumber, result[0].RecordNumber, "Incorrect record returned");
        }

        [TestMethod]
        public void Can_Get_List_Of_Field_Names()
        {
            // Setup
            _store.Initialize();
            _store.StoreLogRecord(new LogRecord
            {
                RecordNumber = 1,
                Fields = new List<LogField>
                {
                    new LogField { FieldName = "f1" },
                    new LogField { FieldName = "f2" }
                }
            });

            _store.StoreLogRecord(new LogRecord
            {
                RecordNumber = 2,
                Fields = new List<LogField>
                {
                    new LogField { FieldName = "f2" },
                    new LogField { FieldName = "f3" }
                }
            });

            // Act
            IList<string> results = _store.GetLogFieldNames(new Guid());

            // Verify
            Assert.IsNotNull(results, "Null list was returned");
            Assert.AreEqual(3, results.Count, "List contained an incorrect number of elements");
            Assert.IsTrue(results.Contains("f1"), "List did not contain the field name 'f1'");
            Assert.IsTrue(results.Contains("f2"), "List did not contain the field name 'f2'");
            Assert.IsTrue(results.Contains("f3"), "List did not contain the field name 'f3'");
        }

        [TestMethod]
        public void Only_Gets_Field_Names_For_Specified_Session()
        {
            // Setup
            Guid session1 = Guid.NewGuid(), session2 = Guid.NewGuid();

            _store.Initialize();
            _store.StoreLogRecord(new LogRecord
            {
                RecordNumber = 1,
                SessionId = session1,
                Fields = new List<LogField>
                {
                    new LogField { FieldName = "f1" },
                    new LogField { FieldName = "f2" }
                }
            });

            _store.StoreLogRecord(new LogRecord
            {
                RecordNumber = 2,
                SessionId = session2,
                Fields = new List<LogField>
                {
                    new LogField { FieldName = "f2" },
                    new LogField { FieldName = "f3" }
                }
            });

            // Act
            IList<string> results = _store.GetLogFieldNames(session2);

            // Verify
            Assert.IsNotNull(results, "Field name list was null");
            Assert.AreEqual(2, results.Count, "Field name list had an incorrect number of elements");
            Assert.IsTrue(results.Contains("f2"), "Field name list did not contain the f2 field");
            Assert.IsTrue(results.Contains("f3"), "Field name list did not contain the f3 field");
        }

        [TestMethod]
        public void Inclusive_Text_Filter_Is_Case_Insensitive()
        {
            // Setup
            _store.Initialize();
            _store.StoreLogRecord(new LogRecord { Fields = new List<LogField> { new LogField { StringValue = "ABC", FieldName = "field" } } });
            var filter = new List<LogFilter> { new LogFilter 
            { 
                FilteredFieldName = "field", 
                FilterType = LogFilterType.Text, 
                ExclusiveFilter = false,
                TextFilter = "abc"
            }};

            // Act
            IList<LogRecord> results = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.IsNotNull(results, "Store returned a null result");
            Assert.AreEqual(1, results.Count, "Incorrect number of recods returned");
        }

        [TestMethod]
        public void Exclusive_Text_Filter_Is_Case_Insensitive()
        {
            // Setup
            _store.Initialize();
            _store.StoreLogRecord(new LogRecord { Fields = new List<LogField> { new LogField { StringValue = "ABC", FieldName = "field" } } });
            var filter = new List<LogFilter> { new LogFilter 
            { 
                FilteredFieldName = "field", 
                FilterType = LogFilterType.Text, 
                ExclusiveFilter = true,
                TextFilter = "abc"
            }};

            // Act
            IList<LogRecord> results = _store.GetFilteredRecords(filter, new Guid(), 2, 1);

            // Verify
            Assert.IsNotNull(results, "Store returned a null result");
            Assert.AreEqual(0, results.Count, "Incorrect number of recods returned");
        }

        [TestMethod]
        public void Store_Only_Retrieves_Log_Records_With_Passed_In_Session_Id()
        {
            // Setup
            _store.Initialize();
            Guid session1 = Guid.NewGuid(), session2 = Guid.NewGuid();

            var record1 = new LogRecord { SessionId = session1, RecordNumber = 1 };
            var record2 = new LogRecord { SessionId = session2, RecordNumber = 2 };
            var record3 = new LogRecord { SessionId = session1, RecordNumber = 3 };

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);
            _store.StoreLogRecord(record3);

            // Act
            IList<LogRecord> result = _store.GetFilteredRecords(null, session1, 2, 1);

            // Verify
            Assert.IsNotNull(result, "Null list was returned");
            Assert.AreEqual(2, result.Count, "List returned an incorrect number of log records");
            Assert.IsTrue(result.Any(x => x.RecordNumber == record1.RecordNumber), "List did not contain record1");
            Assert.IsTrue(result.Any(x => x.RecordNumber == record3.RecordNumber), "List did not contain record3");
        }

        [TestMethod]
        public void Store_Retrieves_Records_In_Specified_Page()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };
            var record3 = new LogRecord { RecordNumber = 3 };
            var record4 = new LogRecord { RecordNumber = 4 };
            var record5 = new LogRecord { RecordNumber = 5 };
            var record6 = new LogRecord { RecordNumber = 6 };

            // Act
            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);
            _store.StoreLogRecord(record3);
            _store.StoreLogRecord(record4);
            _store.StoreLogRecord(record5);
            _store.StoreLogRecord(record6);
            IList<LogRecord> result = _store.GetFilteredRecords(null, new Guid(), 2, 2);

            // Verify
            Assert.AreEqual(2, result.Count, "Result contained an incorrect number of elements");
            Assert.AreEqual(record3.RecordNumber, result[0].RecordNumber, "First result was incorrect");
            Assert.AreEqual(record4.RecordNumber, result[1].RecordNumber, "Second result was incorrect");
        }

        [TestMethod]
        public void Can_Get_Total_Number_Of_Records()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord();
            var record2 = new LogRecord();
            var record3 = new LogRecord();
            var record4 = new LogRecord();
            var record5 = new LogRecord();
            var record6 = new LogRecord();

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);
            _store.StoreLogRecord(record3);
            _store.StoreLogRecord(record4);
            _store.StoreLogRecord(record5);
            _store.StoreLogRecord(record6);

            // Act
            int count = _store.GetTotalRecordCount(null, new Guid());

            // Verify
            Assert.AreEqual(6, count, "Total count was incorrect");
        }

        [TestMethod]
        public void Can_Get_Total_Number_Of_Records_For_Session()
        {
            // Setup
            _store.Initialize();
            Guid session1 = Guid.NewGuid(), session2 = Guid.NewGuid();
            var record1 = new LogRecord { SessionId = session1 };
            var record2 = new LogRecord { SessionId = session2 };
            var record3 = new LogRecord { SessionId = session2 };

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);
            _store.StoreLogRecord(record3);

            // Act
            int s1Count = _store.GetTotalRecordCount(null, session1);
            int s2Count = _store.GetTotalRecordCount(null, session2);

            // Verify
            Assert.AreEqual(1, s1Count, "Total count for session 1 was incorrect");
            Assert.AreEqual(2, s2Count, "Total count for session 2 was incorrect");
        }

        [TestMethod]
        public void Can_Get_Total_Number_For_Filtered_Records()
        {
            // Setup
            _store.Initialize();
            var record1 = new LogRecord { RecordNumber = 1 };
            var record2 = new LogRecord { RecordNumber = 2 };
            var record3 = new LogRecord { RecordNumber = 3 };

            record1.Fields.Add(new LogField { FieldName = "f1", StringValue = "Pass" });
            record2.Fields.Add(new LogField { FieldName = "f1", StringValue = "Fail" });
            record3.Fields.Add(new LogField { FieldName = "f1", StringValue = "Pass" });

            _store.StoreLogRecord(record1);
            _store.StoreLogRecord(record2);
            _store.StoreLogRecord(record3);

            var filter = new List<LogFilter>(
                new LogFilter[] { 
                    new LogFilter { FilteredFieldName = "f1", TextFilter = "Pass", FilterType = LogFilterType.Text, ExclusiveFilter = false } });

            // Act
            int count = _store.GetTotalRecordCount(filter, new Guid());

            // Verify
            Assert.AreEqual(2, count, "Total record count was incorrect");
        }

        [TestMethod]
        public void Store_Returns_Correct_Options_Type()
        {
            // Act
            _store.Initialize();
            LucidityOptionsBase results = _store.GetStoreOptions();

            // Verify
            Assert.IsInstanceOfType(results, _expectedOptionsType, "Log store's options was not the correct type");
        }
    }
}
