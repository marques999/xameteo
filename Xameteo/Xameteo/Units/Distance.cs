using Xameteo.Resx;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Distance : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Application.Group_Distance;

        /// <summary>
        /// </summary>
        public static readonly Distance[] Units =
        {
            new Distance(0, Application.Symbol_Kilometers, Application.Units_Kilometers, null),
            new Distance(1, Application.Symbol_Meters, Application.Units_Meters, value => value * 1000),
            new Distance(2, Application.Symbol_Inches, Application.Units_Inches, value => value * 39370),
            new Distance(3, Application.Symbol_Miles, Application.Units_Miles, value => value * 0.62137)
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