using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Data
{
    public enum LogFilterType { TextFilter, DateFilter }

    public class LogFilter
    {
        public LogFilter()
        {
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;
        }

        /// <summary>
        /// Column the filter should be applied to
        /// </summary>
        public string FilteredColumn { get; set; }

        /// <summary>
        /// Determines if the filter is inclusive or exclusive
        /// </summary>
        public bool ExclusiveFilter { get; set; }

        /// <summary>
        /// Type of filter to apply
        /// </summary>
        public LogFilterType FilterType { get; set; }

        /// <summary>
        /// Text to filter the log record by
        /// </summary>
        public string TextFilter { get; set; }

        /// <summary>
        /// Start date to filter log records by.  If not set it defaults to DateTime.Minvalue
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date to filter log records by.  If not set it defaults to DateTime.Maxvalue
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
