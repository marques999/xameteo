using Xameteo.Resx;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Temperature : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Resources.Group_Temperature;

        /// <summary>
        /// </summary>
        public static readonly Temperature[] Units =
        {
            new Temperature(0, Resources.Symbol_Celsius, Resources.Units_Celsius, null),
            new Temperature(1, Resources.Symbol_Kelvin, Resources.Units_Kelvin, value => value - 273.15),
            new Temperature(2, Resources.Symbol_Fahrenheit, Resources.Units_Fahrenheit, value => value * 1.8 + 32)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Temperature From(int index) => (index < Units.Length) ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Temperature(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}