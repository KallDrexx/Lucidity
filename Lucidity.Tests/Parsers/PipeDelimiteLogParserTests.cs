using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Lucidity.Engine.Data;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Exceptions;

namespace Lucidity.Tests.Parsers
{
    [TestFixture]
    public class PipeDelimiteLogParserTests
    {
        [Test]
        public void Can_Parse_Pipe_Delimited_Logs()
        {
            // Setup
            var parser = new PipeDelimitedLogParser();

            // Act
            IList<LogRecord> result = parser.ParseLog(@"TestData\PipeLogTest.txt");

            // Verify
            Assert.IsNotNull(result, "Parser returned a null result");
            Assert.AreEqual(2, result.Count, "Parser returned an incorrect number of log records");

            Assert.IsNotNull(result[0].Fields, "The first record had a null fields list");
            Assert.AreEqual(3, result[0].Fields.Count, "The first record had an incorrect number of fields");
            Assert.AreEqual("Field1-1", result[0].Fields[0].StringValue, "The first field of the first recod was incorrect");
            Assert.AreEqual("Field1-2", result[0].Fields[1].StringValue, "The second field of the first recod was incorrect");
            Assert.AreEqual("Field1-3", result[0].Fields[2].StringValue, "The third field of the first recod was incorrect");

            Assert.IsNotNull(result[1].Fields, "The second record had a null fields list");
            Assert.AreEqual(3, result[1].Fields.Count, "The second record had an incorrect number of fields");
            Assert.AreEqual("Field2-1", result[1].Fields[0].StringValue, "The first field of the second recod was incorrect");
            Assert.AreEqual("Field2-2", result[1].Fields[1].StringValue, "The second field of the second recod was incorrect");
            Assert.AreEqual("Field2-3", result[1].Fields[2].StringValue, "The third field of the second recod was incorrect");
        }

        [Test]
        [ExpectedException(typeof(LogSourceNotAvailableException))]
        public void Throws_LogSourceNotAvailableException_When_File_Doesnt_Exist()
        {
            // Setup
            var parser = new PipeDelimitedLogParser();

            // Act
            IList<LogRecord> result = parser.ParseLog(@"InvalidFileName.txt");
        }
    }
}
