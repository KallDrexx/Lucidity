using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Options
{
    public class LucidityOption
    {
        public LucidityOption(string propertyName, SupportedOptionTypes optionType) 
        { 
            Name = propertyName;
            OptionType = optionType;
        }

        public string Name { get; protected set; }
        public SupportedOptionTypes OptionType { get; protected set; }
        public object Value { get; set; }
    }
}
