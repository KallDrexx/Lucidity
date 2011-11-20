using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Lucidity.Engine.Data;

namespace Lucidity.StandardTypes.Stores.RavenIndices
{
    public class LogRecord_LogFieldNamesIndex : AbstractIndexCreationTask<LogRecord, string>
    {
        public LogRecord_LogFieldNamesIndex()
        {
            Map = records => (from record in records
                             from field in record.Fields
                             select field.FieldName).Distinct();

        }
    }
}
