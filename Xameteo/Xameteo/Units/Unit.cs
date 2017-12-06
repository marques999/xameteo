namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// </summary>
        public int Id
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
        private readonly string _translate;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public delegate double FormulaDelegate(double value);

        /// <summary>
        /// </summary>
        public string Name => Xameteo.Localization.Get(_translate);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Convert(double value) => $"{Formula?.Invoke(value) ?? value:0.###} {Symbol}";

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        /// <param name="translate"></param>
        /// <param name="formula"></param>
        protected Unit(int index, string symbol, string translate, FormulaDelegate formula)
        {
            Id = index;
            Symbol = symbol;
            Formula = formula;
            _translate = translate;
        }
    }
}