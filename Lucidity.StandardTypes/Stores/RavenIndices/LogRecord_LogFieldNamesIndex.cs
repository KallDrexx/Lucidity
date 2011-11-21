using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Lucidity.Engine.Data;
using Lucidity.StandardTypes.Stores.RavenIndices.MapReduceTypes;

namespace Lucidity.StandardTypes.Stores.RavenIndices
{
    public class LogRecord_LogFieldNamesIndex : AbstractIndexCreationTask<LogRecord, LogSessionFieldNames>
    {
        public LogRecord_LogFieldNamesIndex()
        {
            Map = records => from record in records
                             from field in record.Fields
                             select new
                             {
                                 SessionId = record.SessionId,
                                 FieldName = field.FieldName
                             };

            Reduce = results => from result in results
                                group result by new { result.SessionId, result.FieldName } into g
                                select new
                                {
                                    SessionId = g.Key.SessionId,
                                    FieldName = g.Key.FieldName
                                };
        }
    }
}
