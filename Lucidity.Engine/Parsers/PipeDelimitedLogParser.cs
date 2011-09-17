using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;
using System.IO;
using Lucidity.Engine.Exceptions;

namespace Lucidity.Engine.Parsers
{
    public class PipeDelimitedLogParser : ILogParser
    {
        public string ParserName
        {
            get
            {
                return "Pipe Delimited Log Parser";
            }
        }

        public IList<LogRecord> ParseLog(string logSource)
        {
            var recordList = new List<LogRecord>();
            string lineText;

            // Make sure the log source is a valid file
            if (!File.Exists(logSource))
                throw new LogSourceNotAvailableException(string.Format("The log file '{0}' does not exist", logSource));

            // Open the file passed in by the log source
            var reader = File.OpenText(logSource);

            // Each line represents a separate log record, each field is delimited with a pipe
            while ((lineText = reader.ReadLine()) != null) 
            {
                var record = new LogRecord();
                recordList.Add(record);

                string[] fields = lineText.Split('|');
                foreach (string field in fields)
                    record.Fields.Add(new LogField { StringValue = field });
            }

            return recordList;
        }
    }
}
