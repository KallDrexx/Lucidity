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

        #endregion
        
        #region Member Methods and Properties

        private void SetupOptions()
        {
            _options = new List<LucidityOption>();

            // Create option objects based off of the type's properties
            var options = this.GetType()
                              .GetProperties()
                              .Select(p => new LucidityOption(p, this))
                              .Where(p => p.OptionType != SupportedOptionTypes.None)
                              .ToList();

            _options.AddRange(options);
        }

        

        private List<LucidityOption> _options;
        private Dictionary<SupportedOptionTypes, Type> _optionTypeMap;

        #endregion
    }
}
