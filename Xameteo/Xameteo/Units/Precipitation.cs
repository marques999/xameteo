namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Precipitation : Unit
    {
        /// <summary>
        /// </summary>
        private static int _count;

        /// <summary>
        /// </summary>
        public static readonly Precipitation[] Units =
        {
            new Precipitation("mm", null, new[] { "Milimeters", "Milímetros" }),
            new Precipitation("cm", value => value * 0.1, new[] { "Centimeters", "Centímetros" }),
            new Precipitation("in", value => value * 0.039370, new[] { "Inches", "Polegadas" })
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Precipitation From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Precipitation(string symbol, FormulaDelegate formula, string[] translations) : base(_count++, symbol, formula, translations)
        {
        }
    }
}