using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Utils;
using Lucidity.Engine.Stores;
using Lucidity.StandardTypes.Parsers;
using Lucidity.StandardTypes.Stores;

namespace Lucidity.Tests.Utils
{
    [TestClass]
    public class LucidityImporterTests
    {
        [TestMethod]
        public void Can_Retrieve_All_Available_Log_Parsers()
        {
            // Act
            IList<ILogParser> results = new LucidityImporter().LogParsers;

            // Verify
            Assert.IsNotNull(results, "Method returned null parser list");
            Assert.IsTrue(results.Any(x => x is PipeDelimitedLogParser), "Results did not contain the pipe delimited log parser");
        }

        [TestMethod]
        public void Can_Retrieve_All_Available_Log_Stores()
        {
            // Act
            IList<ILogStore> result = new LucidityImporter().LogStores;

            // Verify
            Assert.IsNotNull(result, "Method returned a null result");
            Assert.IsTrue(result.Any(x => x is InMemoryLogStore), "Result did not contain the InMemoryLogStore");
        }
    }
}
