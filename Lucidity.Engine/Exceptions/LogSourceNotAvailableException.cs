using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Exceptions
{
    public class LogSourceNotAvailableException : Exception
    {
        public LogSourceNotAvailableException(string message) : base(message) { }
    }
}
