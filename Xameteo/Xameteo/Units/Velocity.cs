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
            new Velocity("km/h", "Units_Kilometers_Hour", null),
            new Velocity("knot", "Units_Knots", value => value * 0.53996),
            new Velocity("mph", "Units_Miles_Hour", value => value * 0.621388),
            new Velocity("m/s", "Units_Meters_Second", value => value * 0.277777)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Velocity From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Velocity(string symbol, string translate, FormulaDelegate formula) : base(_count++, symbol, translate, formula)
        {
        }
    }
}