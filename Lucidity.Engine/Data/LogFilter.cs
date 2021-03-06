﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Data
{
    public enum LogFilterType { Text, Date }

    public class LogFilter
    {
        public LogFilter()
        {
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;
        }

        public override string ToString()
        {
            string criteriaString = string.Empty;

            if (FilterType == LogFilterType.Text)
            {
                if (ExclusiveFilter)
                    criteriaString = string.Format("text not containing '{0}'", TextFilter);
                else
                    criteriaString = string.Format("text containing '{0}'", TextFilter);
            }

            else if (FilterType == LogFilterType.Date)
            {
                if (ExclusiveFilter)
                    criteriaString = string.Format("date not between {0} and {1}", StartDate.ToString(), EndDate.ToString());
                else
                    criteriaString = string.Format("date between {0} and {1}", StartDate.ToString(), EndDate.ToString());
            }

            return string.Format("Filtering {0} with {1}", FilteredFieldName, criteriaString);
        }

        /// <summary>
        /// Column the filter should be applied to
        /// </summary>
        public string FilteredFieldName { get; set; }

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
