using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Data
{
    public class LogRecord
    {
        public LogRecord()
        {
            Fields = new List<LogField>();
        }

        public Guid SessionId { get; set; }
        public IList<LogField> Fields { get; set; }
    }
}
