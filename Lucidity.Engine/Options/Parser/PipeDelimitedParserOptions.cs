using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Options.Parser
{
    public class PipeDelimitedParserOptions : LucidityOptionsBase
    {
        public bool FirstColumnContainsFieldNames { get; set; }
    }
}
