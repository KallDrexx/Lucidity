﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Data;
using Lucidity.Engine.Exceptions;
using Lucidity.Engine.Options;

namespace Lucidity.Tests.Parsers
{
    /// <summary>
    /// Base tests all log parsers must pass to be considered fully implemented
    /// </summary>
    [TestClass]
    [Ignore]
    public abstract class ParserBaseTests
    {
        /*************************************************
         * General log source should contain data:
         *  Record 1: Field1-1 
         *            Field1-2
         *            Field1-3
         *  Record 2: Field2-1
         *            Field2-2
         *            Field2-3
         *            
         * Date log source's data should resolve the the following dates:
         * Record 1: 5/2/2001 11:34:15 PM
         *           2011-09-13 13:38:35
         *************************************************/

        protected ILogParser _parser;
        protected Type _expectedOptionsType;
        protected string _generalLogSource; // Log source for most tests
        protected string _dateLogSource; // Log source for date tests

        [TestMethod]
        public void Can_Parse_Pipe_Delimited_Logs()
        {
            // Setup
            IList<LogRecord> records = new List<LogRecord>();

            _parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            _parser.ParseLog(_generalLogSource);

            // Verify
            Assert.AreEqual(2, records.Count, "Parser returned an incorrect number of log records");

            Assert.IsNotNull(records[0].Fields, "The first record had a null fields list");
            Assert.AreEqual(3, records[0].Fields.Count, "The first record had an incorrect number of fields");
            Assert.AreEqual("Field1-1", records[0].Fields[0].StringValue, "The first field of the first recod was incorrect");
            Assert.AreEqual("Field1-2", records[0].Fields[1].StringValue, "The second field of the first recod was incorrect");
            Assert.AreEqual("Field1-3", records[0].Fields[2].StringValue, "The third field of the first recod was incorrect");

            Assert.IsNotNull(records[1].Fields, "The second record had a null fields list");
            Assert.AreEqual(3, records[1].Fields.Count, "The second record had an incorrect number of fields");
            Assert.AreEqual("Field2-1", records[1].Fields[0].StringValue, "The first field of the second recod was incorrect");
            Assert.AreEqual("Field2-2", records[1].Fields[1].StringValue, "The second field of the second recod was incorrect");
            Assert.AreEqual("Field2-3", records[1].Fields[2].StringValue, "The third field of the second recod was incorrect");
        }

        [TestMethod]
        [ExpectedException(typeof(LogSourceNotAvailableException))]
        public void Throws_LogSourceNotAvailableException_When_File_Doesnt_Exist()
        {
            // Setup
            _parser.StoreRecordMethod = (r => { });

            // Act
            _parser.ParseLog(@"InvalidFileName asbadsfjadlfa.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throws_InvalidOperationException_When_No_Store_Record_Delegate_Set()
        {
            // Act
            _parser.ParseLog(_generalLogSource);
        }

        [TestMethod]
        public void Parser_Sets_Field_Names_Based_On_Order()
        {
            // Setup
            IList<LogRecord> records = new List<LogRecord>();

            _parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            _parser.ParseLog(_generalLogSource);

            // Verify
            foreach (var record in records)
                for (int x = 0; x < record.Fields.Count; x++)
                    Assert.AreEqual("Field " + x, record.Fields[x].FieldName, "Field name was incorrect");
        }

        [TestMethod]
        public void Parser_Sets_Date_Field_With_Valid_Dates()
        {
            // Setup
            var records = new List<LogRecord>();
            _parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            _parser.ParseLog(_dateLogSource);

            // Verify
            Assert.AreEqual(new DateTime(2001, 5, 2, 23, 34, 15, 0), records[0].Fields[0].DateValue, "First field had an incorrect date");
            Assert.AreEqual(new DateTime(2011, 9, 13, 13, 38, 35, 0), records[0].Fields[1].DateValue, "Second field had an incorrect date");
        }

        [TestMethod]
        public void Parser_Generates_Unique_Session_Id_And_Assigns_It_To_Records()
        {
            // Setup
            IList<LogRecord> records = new List<LogRecord>();
            _parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            Guid sessionId = _parser.ParseLog(_generalLogSource);

            // Verify
            Assert.AreNotEqual(new Guid(), sessionId, "Session Id was incorrectly set to an empty GUID");
            Assert.IsFalse(records.Any(x => x.SessionId != sessionId), "Not all log records were created with the correct session Id");
        }

        [TestMethod]
        public void Parser_Sets_RecordNumber_Based_On_Order_Record_Is_Parsed_Starting_At_1()
        {
            // Setup
            IList<LogRecord> records = new List<LogRecord>();

            _parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            _parser.ParseLog(_generalLogSource);

            // Verify
            Assert.AreEqual(1, records[0].RecordNumber, "The first record had an incorrect record number");
            Assert.AreEqual(2, records[1].RecordNumber, "The second record had an incorrect record number");
        }

        [TestMethod]
        public void Parser_Returns_Correct_Options_Class()
        {
            // Act
            LucidityOptionsBase results = _parser.GetParserOptions();

            // Verify
            Assert.IsInstanceOfType(results, _expectedOptionsType, "Parser returned an incorrect options class type");
        }
    }
}
