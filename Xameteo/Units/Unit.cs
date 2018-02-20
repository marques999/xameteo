using System;

namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// </summary>
        private readonly string _symbol;

        /// <summary>
        /// </summary>
        private readonly Func<double, double> _formula;

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        /// <param name="name"></param>
        /// <param name="formula"></param>
        protected Unit(int index, string symbol, string name, Func<double, double> formula)
        {
            Id = index;
            _name = name;
            _symbol = symbol;
            _formula = formula;
        }

        /// <summary>
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{_name} ({_symbol})";

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Convert(double value) => $"{_formula?.Invoke(value) ?? value:0.##} {_symbol}";
    }
}