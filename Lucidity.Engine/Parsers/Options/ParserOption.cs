using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Parsers.Options
{
    public class ParserOption
    {
        public string Name { get; set; }
        public Type PropertyType { get; set; }
        public object Value { get; set; }
    }
}
