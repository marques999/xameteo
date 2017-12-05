namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Distance : Unit
    {
        /// <summary>
        /// </summary>
        private static int _count;

        /// <summary>
        /// </summary>
        public static readonly Distance[] Units =
        {
            new Distance("km", null, new[] { "Kilometers", "Quilómetros" }),
            new Distance("m", value => value * 1000, new[] { "Meters", "Metros" }),
            new Distance("in", value => value * 39370, new[] { "Inches", "Polegadas" }),
            new Distance("mi", value => value * 0.62137, new[] { "Miles", "Milhas" })
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Distance From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Distance(string symbol, FormulaDelegate formula, string[] translations) : base(_count++, symbol, formula, translations)
        {
        }
    }
}