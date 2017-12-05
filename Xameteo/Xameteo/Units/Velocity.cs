namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Velocity : Unit
    {
        /// <summary>
        /// </summary>
        private static int _count;

        /// <summary>
        /// </summary>
        public static readonly Velocity[] Units =
        {
            new Velocity("km/h", null, new[] { "Kilometers/hour", "Quilómetros/hora" }),
            new Velocity("knot", value => value * 0.53996, new[] { "Knots", "Nós" }),
            new Velocity("mph", value => value * 0.621388, new[] { "Miles/hour", "Milhas/hora" }),
            new Velocity("m/s", value => value * 0.277777, new[] { "Meters/second", "Metros/segundo" })
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Velocity From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Velocity(string symbol, FormulaDelegate formula, string[] translations) : base(_count++, symbol, formula, translations)
        {
        }
    }
}