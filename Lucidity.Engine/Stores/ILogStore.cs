using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;
using System.Data;

namespace Lucidity.Engine.Stores
{
    /// <summary>
    /// Interface for mechanisms to store, filter, and read log records
    /// </summary>
    public interface ILogStore
    {
        /// <summary>
        /// Adds log records to the store
        /// </summary>
        /// <param name="records"></param>
        void StoreLogRecords(IList<LogRecord> records);

        /// <summary>
        /// Retrieves log records based on the specified filters
        /// </summary>
        /// <param name="filters">List of filters to apply.  Can be null or empty for no filters to be used</param>
        /// <returns></returns>
        DataTable GetFilteredRecords(IList<LogFilter> filters);
    }
}
