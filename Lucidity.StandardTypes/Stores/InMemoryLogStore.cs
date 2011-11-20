using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Data;
using Lucidity.Engine.Exceptions;
using Lucidity.Engine.Options;
using Lucidity.Engine.Options.Store;
using System.ComponentModel.Composition;
using Lucidity.Engine.Stores;

namespace Lucidity.StandardTypes.Stores
{
    [Export(typeof(ILogStore))]
    public class InMemoryLogStore : ILogStore
    {
        public string Name { get { return "In Memory Log Store"; } }

        public void Initialize()
        {
            _logRecords = new List<LogRecord>();
        }

        public void StoreLogRecord(LogRecord record)
        {
            if (_logRecords == null)
                Initialize();

            _logRecords.Add(record);
        }

        public IList<LogRecord> GetFilteredRecords(IList<LogFilter> filters, Guid sessionId, int pageSize, int pageNum)
        {
            var query = GetFilteredQuery(filters, sessionId);
            return query.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetTotalRecordCount(IList<LogFilter> filters, Guid sessionId)
        {
            return GetFilteredQuery(filters, sessionId).Count();
        }

        public IList<string> GetLogFieldNames(Guid sessionId)
        {
            return _logRecords.Where(x => x.SessionId == sessionId)
                              .SelectMany(x => x.Fields)
                              .Select(x => x.FieldName)
                              .Distinct()
                              .ToList();
        }

        public LucidityOptionsBase GetStoreOptions()
        {
            return _options;
        }

        protected IQueryable<LogRecord> GetFilteredQuery(IList<LogFilter> filters, Guid sessionId)
        {
            filters = filters ?? new List<LogFilter>();
            var query = _logRecords.AsQueryable().Where(x => x.SessionId == sessionId);

            // Go through each filter and apply them to the list
            foreach (var filter in filters)
            {
                switch (filter.FilterType)
                {
                    case LogFilterType.Text:
                        if (filter.ExclusiveFilter)
                        {
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName
                                                && y.StringValue.IndexOf(filter.TextFilter, 0, StringComparison.CurrentCultureIgnoreCase) < 0));
                        }
                        else
                        {
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName
                                                && y.StringValue.IndexOf(filter.TextFilter, 0, StringComparison.CurrentCultureIgnoreCase) >= 0));
                        }
                        break;

                    case LogFilterType.Date:
                        if (filter.ExclusiveFilter)
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName && (y.DateValue < filter.StartDate || y.DateValue > filter.EndDate)));
                        else
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName && (y.DateValue > filter.StartDate && y.DateValue < filter.EndDate)));
                        break;

                    default:
                        throw new FilterNotSupportedException(filter.FilterType, this.GetType());
                }
            }
            return query;
        }

        #region Member Variables

        protected IList<LogRecord> _logRecords;
        protected InMemoryLogStoreOptions _options = new InMemoryLogStoreOptions();

        #endregion
    }
}
