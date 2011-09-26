using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;
using Lucidity.Engine.Options;

namespace Lucidity.Engine.Parsers
{
    /// <summary>
    /// Delegate used to push a log record into the log store
    /// </summary>
    /// <param name="record"></param>
    public delegate void StoreRecordDelegate(LogRecord record);

    public interface ILogParser
    {
        /// <summary>
        /// Display name for the log parser
        /// </summary>
        string ParserName { get; }

        /// <summary>
        /// Parses log from the defined source
        /// </summary>
        /// <param name="logSource">Location for the log records</param>
        /// <returns>Generated session id value for the parsing session</returns>
        /// <exception cref="LogSourceNotAvailableException">Thrown when the log source is not available</exception>
        /// <exception cref="InvalidOperationException">Thrown when no delegate is set for storing log records</exception>
        Guid ParseLog(string logSource);

        /// <summary>
        /// Retrieves the options class supported by the parser
        /// </summary>
        /// <returns></returns>
        LucidityOptionsBase GetParserOptions();

        /// <summary>
        /// Method used to store log records as they are parsed
        /// </summary>
        StoreRecordDelegate StoreRecordMethod { get; set; }
    }
}
