using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

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
                                  Value = p.GetValue(this, null)
                              })
                              .ToList();
            return options;
        }

        public void SetOptions(IEnumerable<ParserOption> options)
        {
            foreach (var opt in options)
            {
                // Match the option's name to the property name
                var property = this.GetType().GetProperty(opt.Name);
                property.SetValue(this, opt.Value, null);
            }
        }
    }
}
