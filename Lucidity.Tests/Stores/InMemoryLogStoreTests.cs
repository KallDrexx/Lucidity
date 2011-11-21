using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Data;
using Lucidity.Engine.Stores;
using Lucidity.Engine.Options;
using Lucidity.StandardTypes.Stores;
using Lucidity.StandardTypes.Stores.Options;

namespace Lucidity.Tests.Stores
{
    [TestClass]
    public class InMemoryLogStoreTests : StoreBaseTests
    {
        [TestInitialize]
        public void Setup()
        {
            _store = new InMemoryLogStore();
            _expectedOptionsType = typeof(InMemoryLogStoreOptions);
        }
    }
}
