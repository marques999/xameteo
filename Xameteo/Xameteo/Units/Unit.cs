namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// </summary>
        public int ID
        {
            get;
        }

        /// <summary>
        /// </summary>
        public string Symbol
        {
            get;
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
        /// <param name="value"></param>
        /// <returns></returns>
        public delegate double FormulaDelegate(double value);

        /// <summary>
        /// </summary>
        public string Name => _localizations[(int)Xameteo.Settings.Locale] ?? _localizations[0];

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Convert(double value) => $"{Formula?.Invoke(value) ?? value:0.###} {Symbol}";

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        /// <param name="formula"></param>
        /// <param name="translations"></param>
        protected Unit(int index, string symbol, FormulaDelegate formula, string[] translations)
        {
            ID = index;
            Symbol = symbol;
            Formula = formula;
            _localizations = translations;
        }
    }
}