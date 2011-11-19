using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Utils;
using Lucidity.Engine.Stores;
using Lucidity.StandardTypes.Stores;

namespace Lucidity.Tests.Utils
{
    [TestClass]
    public class LogStoreUtilsTests
    {
        [TestMethod]
        public void Can_Retrieve_All_Available_Log_Stores()
        {
            // Act
            IList<ILogStore> result = LogStoreUtils.GetAvailableLogStores();

            // Verify
            Assert.IsNotNull(result, "Method returned a null result");
            Assert.AreEqual(1, result.Count, "Incorrect number of stores were returned");
            Assert.IsTrue(result.Any(x => x is InMemoryLogStore), "Result did not contain the InMemoryLogStore");
        }
    }
}
