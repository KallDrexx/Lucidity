using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Data;
using Lucidity.Engine.Stores;
using Lucidity.Engine.Options;
using Lucidity.Engine.Options.Store;
using Lucidity.StandardTypes.Stores;

namespace Lucidity.Tests.Stores
{
    [TestClass]
    public class InMemoryLogStoreTests : StoreBaseTests
    {
        [TestInitialize]
        public void Setup()
        {
            _store = new InMemoryLogStore();
        }

        [TestMethod]
        public void Store_Returns_Correct_Options_Type()
        {
            // Act
            LucidityOptionsBase results = _store.GetStoreOptions();

            // Verify
            Assert.IsInstanceOfType(results, typeof(InMemoryLogStoreOptions), "Log store's options was not the correct type");
        }
    }
}
