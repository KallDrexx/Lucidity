using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Lucidity.Engine.Exceptions;

namespace Lucidity.Engine.Options
{
    public class LucidityOption
    {
        public LucidityOption(PropertyInfo propertyInfo, LucidityOptionsBase optionClassInstance) 
        {
            _propertyInfo = propertyInfo;
            _optionClassInstance = optionClassInstance;

            Name = _propertyInfo.Name;
            OptionType = GetSupportedOptionType(_propertyInfo.PropertyType);

            // Setup the option type map
            _optionTypeMap = new Dictionary<SupportedOptionTypes, Type>();
            _optionTypeMap.Add(SupportedOptionTypes.String, typeof(string));
            _optionTypeMap.Add(SupportedOptionTypes.Bool, typeof(bool));
            _optionTypeMap.Add(SupportedOptionTypes.Decimal, typeof(decimal));
            _optionTypeMap.Add(SupportedOptionTypes.Integer, typeof(int));
        }

        public string Name { get; protected set; }
        public SupportedOptionTypes OptionType { get; protected set; }

        public object Value 
        {
            get { return _propertyInfo.GetValue(_optionClassInstance, null); }
            set
            {
                if (value == null)
                    throw new NullOptionValueNotAllowedException(this);

                // Set the property based on its option type
                if (_optionTypeMap.ContainsKey(this.OptionType))
                {
                    if (_propertyInfo.PropertyType != _optionTypeMap[this.OptionType] || value.GetType() != _optionTypeMap[this.OptionType])
                        throw new OptionTypeMismatchException(_propertyInfo.Name, _optionTypeMap[this.OptionType], _propertyInfo.PropertyType, value.GetType());

                    _propertyInfo.SetValue(_optionClassInstance, value, null);
                }
            }
        }

        protected SupportedOptionTypes GetSupportedOptionType(Type tp)
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

        protected PropertyInfo _propertyInfo;
        protected LucidityOptionsBase _optionClassInstance;
        protected Dictionary<SupportedOptionTypes, Type> _optionTypeMap;
    }
}
