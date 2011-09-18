using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Exceptions;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Data;

namespace Lucidity.Tests.Parsers
{
    [TestClass]
    public class PipeDelimitedLogParserTests
    {
        [TestMethod]
        [DeploymentItem(@"TestData\pipeLogTest.txt")]
        public void Can_Parse_Pipe_Delimited_Logs()
        {
            // Setup
            var parser = new PipeDelimitedLogParser();
            IList<LogRecord> records = new List<LogRecord>();

            parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            parser.ParseLog("PipeLogTest.txt");

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
            var parser = new PipeDelimitedLogParser();
            parser.StoreRecordMethod = (r => { });

            // Act
            parser.ParseLog(@"InvalidFileName.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [DeploymentItem(@"TestData\pipeLogTest.txt")]
        public void Throws_InvalidOperationException_When_No_Store_Record_Delegate_Set()
        {
            // Setup
            var parser = new PipeDelimitedLogParser();

            // Act
            parser.ParseLog("pipeLogTest.txt");
        }

        [TestMethod]
        [DeploymentItem(@"TestData\pipeLogTest.txt")]
        public void Parser_Sets_Field_Names_Based_On_Order()
        {
            // Setup
            var parser = new PipeDelimitedLogParser();
            IList<LogRecord> records = new List<LogRecord>();

            parser.StoreRecordMethod = (r => records.Add(r));

            // Act
            parser.ParseLog("PipeLogTest.txt");

            // Verify
            foreach (var record in records)
                for (int x = 0; x < record.Fields.Count; x++)
                    Assert.AreEqual("Field " + x, record.Fields[x].FieldName, "Field name was incorrect");
        }
    }
}