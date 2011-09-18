using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Utils;

namespace Lucidity.Tests.Utils
{
    [TestClass]
    public class LogParserUtilsTests
    {
        [TestMethod]
        public void Can_Retrieve_All_Available_Log_Parsers()
        {
            // Act
            IList<ILogParser> results = LogParserUtils.GetAvailableLogParsers();

            // Verify
            Assert.IsNotNull(results, "Method returned null parser list");
            Assert.AreEqual(1, results.Count, "Incorrect number of parsers returned");
            Assert.IsTrue(results.Any(x => x is PipeDelimitedLogParser), "Results did not contain the pipe delimited log parser");
        }
    }
}
