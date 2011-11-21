using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Stores;
using Lucidity.Engine.Options;
using Lucidity.Engine.Data;
using Raven.Client.Document;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Client.Linq;
using Lucidity.StandardTypes.Stores.RavenIndices;
using Lucidity.StandardTypes.Stores.Options;
using Lucidity.StandardTypes.Stores.RavenIndices.MapReduceTypes;
using Raven.Abstractions.Data;
using Raven.Abstractions.Indexing;

namespace Lucidity.StandardTypes.Stores
{
    public class RavenDbLogStore : ILogStore
    {
        public bool UseInMemoryStore { get; set; }

        public string Name { get { return "Raven DB Log Store"; } }

        public void Initialize()
        {
            if (_options.RunInMemory)
                _store = new EmbeddableDocumentStore { RunInMemory = true };
            else
                _store = new EmbeddableDocumentStore { DataDirectory = "ravenData" };

            _store.Initialize();

            // Create the indices and facets
            Raven.Client.Indexes.IndexCreation.CreateIndexes(typeof(LogRecord_LogFieldNamesIndex).Assembly, _store);
        }

        public void StoreLogRecord(LogRecord record)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(record);
                session.SaveChanges();
            }
        }

        public IList<LogRecord> GetFilteredRecords(IList<LogFilter> filters, Guid sessionId, int pageSize, int pageNum)
        {
            using (var session = _store.OpenSession())
            {
                var recordQuery = session.Query<LogRecord>().Where(x => x.SessionId == sessionId);

                // Loop through all the filters and apply them
                recordQuery = ApplyFiltersToQuery(recordQuery, filters);

                return recordQuery.OrderBy(x => x.RecordNumber)
                                  .Skip((pageNum - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
            }
        }

        public int GetTotalRecordCount(IList<LogFilter> filters, Guid sessionId)
        {
            using (var session = _store.OpenSession())
            {
                var query = session.Query<LogRecord>().Where(x => x.SessionId == sessionId);
                query = ApplyFiltersToQuery(query, filters);
                return query.Count();
            }
        }

        public IList<string> GetLogFieldNames(Guid sessionId)
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<LogSessionFieldNames, LogRecord_LogFieldNamesIndex>()
                              .Where(x => x.SessionId == sessionId)
                              .Select(x => x.FieldName)
                              .Customize(x => x.WaitForNonStaleResultsAsOfNow())
                              .ToList();
            }
        }

        public LucidityOptionsBase GetStoreOptions()
        {
            return _options;
        }

        protected IRavenQueryable<LogRecord> ApplyFiltersToQuery(IRavenQueryable<LogRecord> query, IList<LogFilter> filters)
        {
            if (filters == null)
                return query;

            foreach (var filter in filters)
            {
                switch (filter.FilterType)
                {
                    case LogFilterType.Text:
                        if (filter.ExclusiveFilter)
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName && !y.StringValue.Contains(filter.TextFilter)));
                        else
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName && y.StringValue.Contains(filter.TextFilter)));
                        break;

                    case LogFilterType.Date:
                        if (filter.ExclusiveFilter)
                        {
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName
                                                    && (y.DateValue < filter.StartDate || y.DateValue > filter.EndDate)));
                        }
                        else
                        {
                            query = query.Where(x => x.Fields.Any(y => y.FieldName == filter.FilteredFieldName
                                                    && (y.DateValue >= filter.StartDate && y.DateValue <= filter.EndDate)));
                        }
                        break;

                    default:
                        throw new NotSupportedException(
                            string.Format("The {0} filter is not supported by the RavenDbLogStore", filter.FilterType.ToString()));
                }
            }

            return query;
        }

        #region Member Variables

        protected IDocumentStore _store;
        protected RavenDbLogStoreOptions _options = new RavenDbLogStoreOptions();

        #endregion
    }
}
