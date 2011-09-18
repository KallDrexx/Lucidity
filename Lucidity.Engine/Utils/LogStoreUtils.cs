using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Stores;
using System.Reflection;

namespace Lucidity.Engine.Utils
{
    public class LogStoreUtils
    {
        public static IList<ILogStore> GetAvailableLogStores()
        {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.GetInterfaces().Any(y => y == typeof(ILogStore)))
                            .Select(x => (ILogStore)Activator.CreateInstance(x))
                            .ToList();
        }
    }
}
