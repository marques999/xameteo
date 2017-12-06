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
            new Distance("km", "Units_Kilometers", null),
            new Distance("m", "Units_Meters", value => value * 1000),
            new Distance("in", "Units_Inches", value => value * 39370),
            new Distance("mi", "Units_Miles", value => value * 0.62137)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Distance From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Distance(string symbol, string translate, FormulaDelegate formula) : base(_count++, symbol, translate, formula)
        {
        }
    }
}