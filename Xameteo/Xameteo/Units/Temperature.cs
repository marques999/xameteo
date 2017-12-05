namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Temperature : Unit
    {
        /// <summary>
        /// </summary>
        private static int _count;
        
        /// <summary>
        /// </summary>
        public static readonly Temperature[] Units =
        {
            new Temperature("C", null, new[] { "Celsius", "Celsius" }),
            new Temperature("F", value => value - 273.15, new[] { "Kelvin", "Kelvin" }),
            new Temperature("K", value => value * 1.8 + 32, new[] { "Fahrenheit", "Fahrenheit" })
        };

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        public static Temperature From(int index) => (index < Units.Length) ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Temperature(string symbol, FormulaDelegate formula, string[] translations) : base(_count++, symbol, formula, translations)
        {
        }
    }
}