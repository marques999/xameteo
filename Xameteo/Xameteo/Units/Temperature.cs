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
            new Temperature("C", "Units_Celsius", null),
            new Temperature("K", "Units_Kelvin", value => value - 273.15),
            new Temperature("F", "Units_Fahrenheit", value => value * 1.8 + 32)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Temperature From(int index) => (index < Units.Length) ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Temperature(string symbol, string translate, FormulaDelegate formula) : base(_count++, symbol, translate, formula)
        {
        }
    }
}