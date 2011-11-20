using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.StandardTypes.Stores;
using System.Transactions;
using Lucidity.StandardTypes.Stores.Options;

namespace Lucidity.Tests.Stores
{   
    [TestClass]
    public class RavenDbLogStoreTests : StoreBaseTests
    {
        [TestInitialize]
        public void Setup()
        {
            _store = new RavenDbLogStore();
            
            // Set the raven store to be run in memory
            var options = _store.GetStoreOptions() as RavenDbLogStoreOptions;
            if (options != null)
                options.RunInMemory = true;

            _expectedOptionsType = typeof(RavenDbLogStoreOptions);
        }
    }
}