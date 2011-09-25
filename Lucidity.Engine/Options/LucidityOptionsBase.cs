using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Lucidity.Engine.Exceptions;

namespace Lucidity.Engine.Options
{
    public abstract class LucidityOptionsBase
    {
        public LucidityOptionsBase()
        {
            _optionTypeMap = new Dictionary<SupportedOptionTypes, Type>();
            _optionTypeMap.Add(SupportedOptionTypes.String, typeof(string));
            _optionTypeMap.Add(SupportedOptionTypes.Bool, typeof(bool));
            _optionTypeMap.Add(SupportedOptionTypes.Decimal, typeof(decimal));
            _optionTypeMap.Add(SupportedOptionTypes.Integer, typeof(int));
        }

        #region Public Methods

        /// <summary>
        /// Retrieves a set of options available for the current Type
        /// </summary>
        /// <returns></returns>
        public IList<LucidityOption> GetOptions()
        {
            if (_options == null)
                SetupOptions();

            return _options;
        }

        /// <summary>
        /// Sets the value of all the properties to the value specified by their corresponding options
        /// </summary>
        /// <exception cref="OptionTypeMismatchException">Thrown when a property type is not supported by it's option type</exception>
        public void UpdateOptionValues()
        {
            if (_options == null)
                return;

            foreach (var opt in _options)
            {
                // Match the option's name to the property name
                var property = this.GetType().GetProperty(opt.Name);

                // Set the property based on its option type
                if (_optionTypeMap.ContainsKey(opt.OptionType))
                {
                    if (property.PropertyType != _optionTypeMap[opt.OptionType] || opt.Value.GetType() != _optionTypeMap[opt.OptionType])
                        throw new OptionTypeMismatchException(property.Name, _optionTypeMap[opt.OptionType], property.PropertyType, opt.Value.GetType());

                    property.SetValue(this, opt.Value, null);
                }
            }
        }

        #endregion
        
        #region Member Methods and Properties

        private void SetupOptions()
        {
            _options = new List<LucidityOption>();

            // Create option objects based off of the type's properties
            var options = this.GetType()
                              .GetProperties()
                              .Select(p => new LucidityOption(p.Name, GetSupportedOptionType(p.PropertyType))
                              {
                                  Value = p.GetValue(this, null)
                              })
                              .Where(p => p.OptionType != SupportedOptionTypes.None)
                              .ToList();

            _options.AddRange(options);
        }

        private SupportedOptionTypes GetSupportedOptionType(Type tp)
        {
            if (tp == typeof(string))
                return SupportedOptionTypes.String;
            else if (tp == typeof(int))
                return SupportedOptionTypes.Integer;
            else if (tp == typeof(decimal))
                return SupportedOptionTypes.Decimal;
            else if (tp == typeof(bool))
                return SupportedOptionTypes.Bool;

            return SupportedOptionTypes.None;
        }

        private List<LucidityOption> _options;
        private Dictionary<SupportedOptionTypes, Type> _optionTypeMap;

        #endregion
    }
}
