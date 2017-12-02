namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public delegate double FormulaDelegate(double value);

    /// <summary>
    /// </summary>
    public class Unit
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
        public string ToString(double value)
        {
            return $"{Convert(value):0.###} {Get((int) Xameteo.Settings.Locale)}";
        }

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string Get(int index)
        {
            return index < _localizations.Length ? _localizations[index] : _localizations[0];
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