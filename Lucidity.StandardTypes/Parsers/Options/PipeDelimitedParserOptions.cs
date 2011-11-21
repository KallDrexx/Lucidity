using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Options;

namespace Lucidity.StandardTypes.Parsers.Options
{
    public class PipeDelimitedParserOptions : LucidityOptionsBase
    {
        public bool FirstColumnContainsFieldNames { get; set; }
    }
}
