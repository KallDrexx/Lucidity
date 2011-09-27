using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucidity.Engine.Options;

namespace Lucidity.Engine.Exceptions
{
    public class NullOptionValueNotAllowedException : Exception
    {
        public NullOptionValueNotAllowedException(LucidityOption option)
            : base(string.Format("Attempted to set the Lucidity option of {0} to null, but null option values are not allowed", option.Name))
        {

        }
    }
}
