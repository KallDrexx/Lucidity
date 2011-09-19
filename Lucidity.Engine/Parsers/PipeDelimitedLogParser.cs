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
        public string ParserName { get { return "Pipe Delimited Log Parser"; } }

        public void ParseLog(string logSource)
        {
            string lineText;

            // Make sure we have a valid delegate to store records with
            if (StoreRecordMethod == null)
                throw new InvalidOperationException("No method assigned for storing log records");

            // Make sure the log source is a valid file
            if (!File.Exists(logSource))
                throw new LogSourceNotAvailableException(string.Format("The log file '{0}' does not exist", logSource));

            // Open the file passed in by the log source
            var reader = File.OpenText(logSource);

            // Each line represents a separate log record, each field is delimited with a pipe
            while ((lineText = reader.ReadLine()) != null) 
            {
                var record = new LogRecord();

                string[] fields = lineText.Split('|');

                for (int x = 0; x < fields.Length; x++)
                {
                    DateTime parsedDate;
                    if (!DateTime.TryParse(fields[x], out parsedDate))
                        record.Fields.Add(new LogField { StringValue = fields[x], FieldName = "Field " + x });
                    else
                        record.Fields.Add(new LogField { StringValue = fields[x], DateValue = parsedDate, FieldName = "Field " + x });
                }

                StoreRecordMethod(record);
            }
        }

        public StoreRecordDelegate StoreRecordMethod { get; set; }
    }
}
