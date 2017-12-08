namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// </summary>
        private readonly FormulaDelegate _formula;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected delegate double FormulaDelegate(double value);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name} ({Symbol})";

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Convert(double value) => $"{_formula?.Invoke(value) ?? value:N2} {Symbol}";

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
            _formula = formula;
        }
    }
}