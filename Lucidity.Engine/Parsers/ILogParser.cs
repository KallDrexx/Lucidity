using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;

namespace Lucidity.Engine.Parsers
{
    public interface ILogParser
    {
        /// <summary>
        /// Friendly name for the log parser
        /// </summary>
        string ParserName { get; }

        /// <summary>
        /// Parses log from the defined source
        /// </summary>
        /// <param name="logSource"></param>
        /// <returns>Returns a collection of record from the log</returns>
        IList<LogRecord> ParseLog(string logSource);
    }
}
