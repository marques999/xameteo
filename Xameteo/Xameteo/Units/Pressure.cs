using Xameteo.Resx;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Pressure : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Application.Group_Pressure;

        /// <summary>
        /// </summary>
        public static readonly Pressure[] Units =
        {
            new Pressure(0, Application.Symbol_Millibars, Application.Units_Millibars, null),
            new Pressure(1, Application.Symbol_Kilopascal, Application.Units_Kilopascal, value => value * 0.1),
            new Pressure(2, Application.Symbol_Torr, Application.Units_Torr, value => value * 0.75006375541921),
            new Pressure(3, Application.Symbol_Atmosphere, Application.Units_Atmosphere, value => value * 0.00098692326671601)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Pressure From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Pressure(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}