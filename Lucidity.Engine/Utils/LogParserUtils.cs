using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Parsers;

namespace Lucidity.Engine.Utils
{
    public class LogParserUtils
    {
        public static IList<ILogParser> GetAvailableLogParsers()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.GetInterfaces().Any(y => y == typeof(ILogParser)))
                            .Select(x => (ILogParser)Activator.CreateInstance(x))
                            .ToList();
        }
    }
}
