using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Options;

namespace Lucidity.Engine.Exceptions
{
    public class OptionTypeMismatchException : Exception
    {
        public OptionTypeMismatchException(string propertyName, Type expectedType, Type actualType, Type valueType)
            : base(
                string.Format("The {0} property has a type of {1} and the option's value has a type of {2} but the option was expecting a type of {3}", 
                    propertyName, actualType.Name, valueType, actualType))
        {
        }
    }
}
