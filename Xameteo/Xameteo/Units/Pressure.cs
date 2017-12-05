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
            new Pressure("mbar", null, new[] { "Millibars", "Milibares" }),
            new Pressure("kPA", value => value * 0.1, new[] { "Kilopascal", "Quilopascal" }),
            new Pressure("torr", value => value * 0.75006375541921, new[] { "Torr (mmHg)", "Torr (mmHg)" }),
            new Pressure("atm", value => value * 0.00098692326671601, new[] { "Atmosphere", "Atmosferas" })
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Pressure From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Pressure(string symbol, FormulaDelegate formula, string[] translations) : base(_count++, symbol, formula, translations)
        {
        }
    }
}