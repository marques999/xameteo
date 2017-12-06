namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Pressure : Unit
    {
        /// <summary>
        /// </summary>
        private static int _count;

        /// <summary>
        /// </summary>
        public static readonly Pressure[] Units =
        {
            new Pressure("mbar", "Units_Millibars", null),
            new Pressure("kPA", "Units_Kilopascal", value => value * 0.1),
            new Pressure("torr", "Units_Torr", value => value * 0.75006375541921),
            new Pressure("atm", "Units_Atmosphere", value => value * 0.00098692326671601)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Pressure From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Pressure(string symbol, string translate, FormulaDelegate formula) : base(_count++, symbol, translate, formula)
        {
        }
    }
}