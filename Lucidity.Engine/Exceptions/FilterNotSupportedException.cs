using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;

namespace Lucidity.Engine.Exceptions
{
    public class FilterNotSupportedException : Exception
    {
        public FilterNotSupportedException(LogFilterType filterType, Type storeType)
            : base(string.Format("The filter type of {0} is not supported by the {1} log record store", filterType.ToString(), storeType.Name))
        {
            FilterType = filterType;
            StoreType = storeType;
        }

        public LogFilterType FilterType { get; protected set; }
        public Type StoreType { get; set; }
    }
}
