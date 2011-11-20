using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Options;

namespace Lucidity.StandardTypes.Stores.Options
{
    public class RavenDbLogStoreOptions : LucidityOptionsBase
    {
        public bool RunInMemory { get; set; }
    }
}
