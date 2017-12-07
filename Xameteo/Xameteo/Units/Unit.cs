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
        public string Name
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
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        /// <param name="name"></param>
        /// <param name="formula"></param>
        protected Unit(int index, string symbol, string name, FormulaDelegate formula)
        {
            Id = index;
            Name = name;
            Symbol = symbol;
            Formula = formula;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public delegate double FormulaDelegate(double value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Convert(double value) => $"{Formula?.Invoke(value) ?? value:0.###} {Symbol}";
    }
}