using System.Linq;
using System.Collections.Generic;

using Plugin.Settings.Abstractions;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class UnitFactory
    {
        /// <summary>
        /// </summary>
        private readonly string _preferencesKey;

        /// <summary>
        /// </summary>
        /// <param name="preferencesKey"></param>
        public UnitFactory(string preferencesKey)
        {
            _preferencesKey = preferencesKey;
        }

        /// <summary>
        /// </summary>
        /// <param name="settingsManager"></param>
        /// <returns></returns>
        public Unit Load(ISettings settingsManager)
        {
            return this[settingsManager.GetValueOrDefault(_preferencesKey, _default.Name)];
        }

        /// <summary>
        /// </summary>
        /// <param name="settingsManager"></param>
        /// <param name="current"></param>
        public void Save(ISettings settingsManager, Unit current)
        {
            settingsManager.AddOrUpdateValue(_preferencesKey, current.Name);
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="formula"></param>
        /// <param name="translations"></param>
        public void RegisterUnit(string name, FormulaDelegate formula, string[] translations)
        {
            var unit = new Unit(name, formula, translations);

            _table.Add(name, unit);

            if (formula == null && _default == null)
            {
                _default = unit;
            }
        }

        /// <summary>
        /// </summary>
        private Unit _default;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<Unit> Enumerate() => _table.Values.ToList();

        /// <summary>
        /// </summary>
        private readonly Dictionary<string, Unit> _table = new Dictionary<string, Unit>();

        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public Unit this[string unit] => _table.TryGetValue(unit, out var value) ? value : _default;
    }
}