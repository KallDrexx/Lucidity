using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;

namespace Lucidity.Engine.Stores
{
    public class InMemoryLogStore : ILogStore
    {
        #region Public Properties and Methods

        public string Name { get { return "In Memory Log Store"; } }

        public void StoreLogRecord(LogRecord record)
        {
            _logRecords.Add(record);
        }

        public IList<LogRecord> GetFilteredRecords(IList<LogFilter> filters)
        {
            var query = _logRecords.AsQueryable();
            filters = filters ?? new List<LogFilter>();

            // Go through each filter and apply them to the list
            foreach (var filter in filters)
            {
                switch (filter.FilterType)
                {
                    case LogFilterType.TextFilter:
                        if (filter.ExclusiveFilter)
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredColumn && !y.StringValue.Contains(filter.TextFilter)));
                        else
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredColumn && y.StringValue.Contains(filter.TextFilter)));
                        break;
                }
            }

            return query.ToList();
        }

        #endregion

        #region Member Variables

        protected IList<LogRecord> _logRecords = new List<LogRecord>();

        #endregion
    }
}
