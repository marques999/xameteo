using Xameteo.Resx;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Distance : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Resources.Group_Distance;

        /// <summary>
        /// </summary>
        public static readonly Distance[] Units =
        {
            new Distance(0, Resources.Symbol_Kilometers, Resources.Units_Kilometers, null),
            new Distance(1, Resources.Symbol_Meters, Resources.Units_Meters, value => value * 1000),
            new Distance(2, Resources.Symbol_Inches, Resources.Units_Inches, value => value * 39370),
            new Distance(3, Resources.Symbol_Miles, Resources.Units_Miles, value => value * 0.62137)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Distance From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Distance(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}