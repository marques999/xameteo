using Xameteo.Globalization;

namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    internal class Unit
    {
        /// <summary>
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public FormulaDelegate Formula
        {
            get;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public delegate double FormulaDelegate(double value);

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="formula"></param>
        /// <param name="translations"></param>
        public Unit(string name, FormulaDelegate formula, string[] translations)
        {
            Name = name;
            Formula = formula;
            _localizations = translations;
        }

        /// <summary>
        /// </summary>
        private readonly string[] _localizations;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Convert(double value) => Formula?.Invoke(value) ?? value;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToString(double value) => $"{Convert(value):0.###} {Name}";

        /// <summary>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string Translate(Locale locale) => _localizations[(int)locale] ?? _localizations[0];
    }
}