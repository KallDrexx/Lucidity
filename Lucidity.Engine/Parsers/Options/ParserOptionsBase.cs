using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Engine.Parsers.Options
{
    public abstract class ParserOptionsBase
    {
        /// <summary>
        /// Retrieves a list of options used by the parser
        /// </summary>
        /// <returns></returns>
        public IList<ParserOption> GetOptions()
        {
            // Create parser option objects based off of the type's properties
            var options = this.GetType()
                              .GetProperties()
                              .Select(p => new ParserOption
                              {
                                  Name = p.Name,
                                  PropertyType = p.PropertyType,
                                  CurrentValue = p.GetValue(this, null).ToString()
                              })
                              .ToList();
            return options;
        }
    }
}
