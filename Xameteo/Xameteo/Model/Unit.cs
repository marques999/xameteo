using System;
using System.Collections.Generic;
using Xameteo.Globalization;
using Xameteo.Helpers;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public delegate double FormulaDelegate(double value);

    /// <summary>
    /// </summary>
    internal class Unit
    {
        public string Name
        {
            get;
            set;
        }

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
        public LocalizationPair Enumerate(Locale locale)
        {
            return new LocalizationPair(Name, _localizations[(int)locale] ?? _localizations[0]);
        }

        /// <summary>
        /// </summary>
        public FormulaDelegate Formula
        {
            get;
        }

        /// <summary>
        /// </summary>
        private readonly string[] _localizations;

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
    }
}