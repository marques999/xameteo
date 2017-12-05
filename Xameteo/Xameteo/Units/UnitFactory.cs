using System;
using System.Globalization;
using System.Collections.Generic;

using Xamarin.Forms;

using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    internal abstract class UnitFactory
    {
        /// <summary>
        /// </summary>
        public string Type
        {
            get;
        }

        /// <summary>
        /// </summary>
        public Unit[] Units
        {
            get;
        }

        /// <summary>
        /// </summary>
        private readonly Unit _default;

        /// <summary>
        /// </summary>
        private readonly ISettings _settings;

        /// <summary>
        /// </summary>
        private readonly Dictionary<string, Unit> _table = new Dictionary<string, Unit>();

        /// <summary>
        /// </summary>
        public Unit Current
        {
            get
            {
                try
                {
                    return _table[_settings.GetValueOrDefault(Type, _default.Name)];
                }
                catch
                {
                    return _default;
                }
            }
            set
            {
                if (_table.ContainsKey(value.Name))
                {
                    _settings.AddOrUpdateValue(Type, Current.Name);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="type"></param>
        /// <param name="units"></param>
        protected UnitFactory(string type, ISettings settings, Unit[] units)
        {
            Type = type;
            Units = units;
            _settings = settings;

            foreach (var unit in units)
            {
                _table.Add(unit.Name, unit);

                if (unit.Formula == null && _default == null)
                {
                    _default = unit;
                }
            }
        }
    }
}