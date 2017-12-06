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
            new Precipitation("mm", "Units_Millimeters", null),
            new Precipitation("cm", "Units_Centimeters", value => value * 0.1),
            new Precipitation("in", "Units_Inches", value => value * 0.039370)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Precipitation From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Precipitation(string symbol, string translate, FormulaDelegate formula) : base(_count++, symbol, translate, formula)
        {
        }
    }
}