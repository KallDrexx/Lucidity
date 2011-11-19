using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Parsers;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Lucidity.Engine.Stores;

namespace Lucidity.Engine.Utils
{
    public class LucidityImporter
    {
        [ImportMany(typeof(ILogParser))]
        public IList<ILogParser> LogParsers { get; protected set; }

        [ImportMany(typeof(ILogStore))]
        public IList<ILogStore> LogStores { get; protected set; }

        public LucidityImporter()
        {
            LogParsers = new List<ILogParser>();
            LogStores = new List<ILogStore>();

            // Import all types available in the current assembly's directory
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
