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
        /// Display name for the log store
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Performs any initialization required for the log store
        /// </summary>
        void Initialize();

        /// <summary>
        /// Adds log record to the store
        /// </summary>
        /// <param name="records"></param>
        void StoreLogRecord(LogRecord record);

        /// <summary>
        /// Retrieves log records based on the specified filters
        /// </summary>
        /// <param name="filters">List of filters to apply.  Can be null or empty for no filters to be used</param>
        /// <returns>Log Records that match the specified filters</returns>
        /// <exception cref="FilterNotSupportedException">Thrown when the store does not support the specified server</exception>
        IList<LogRecord> GetFilteredRecords(IList<LogFilter> filters);
    }
}
