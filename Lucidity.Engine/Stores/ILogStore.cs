using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;
using System.Data;
using Lucidity.Engine.Options;

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
        /// <param name="sessionId">Session ID for the logs to retrieve</param>
        /// <param name="pageSize">Number of records in each results page</param>
        /// <param name="pageNum">Page number (starting from 1) for the record set to retrieve</param>
        /// <returns>Log Records that match the specified filters</returns>
        /// <exception cref="FilterNotSupportedException">Thrown when the store does not support the specified server</exception>
        IList<LogRecord> GetFilteredRecords(IList<LogFilter> filters, Guid sessionId, int pageSize, int pageNum);

        /// <summary>
        /// Retrieves the total number of records in the store for the specified session and filters
        /// </summary>
        /// <param name="filters">List of filters to apply.  Can be null or empty for no filters to be used</param>
        /// <param name="sessionId">Session ID for the logs to retrieve</param>
        /// <returns></returns>
        int GetTotalRecordCount(IList<LogFilter> filters, Guid sessionId);

        /// <summary>
        /// Retrieves a list of names for the fields in the log records
        /// </summary>
        /// <returns></returns>
        IList<string> GetLogFieldNames();

        /// <summary>
        /// Retrieves the options supported by the log store
        /// </summary>
        /// <returns></returns>
        LucidityOptionsBase GetStoreOptions();
    }
}
