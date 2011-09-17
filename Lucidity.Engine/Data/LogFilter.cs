using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Data
{
    public enum LogFilterType { TextFilter, DateFilter }

    public class LogFilter
    {
        /// <summary>
        /// Column the filter should be applied to
        /// </summary>
        public int ColumnNumber { get; set; }

        /// <summary>
        /// Text to filter the log record by
        /// </summary>
        public string TextFilter { get; set; }

        /// <summary>
        /// Start date to filter log records by
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End date to filter log records by
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
