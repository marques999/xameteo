using Xameteo.Resx;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Precipitation : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Application.Group_Precipitation;

        /// <summary>
        /// </summary>
        public static readonly Precipitation[] Units =
        {
            new Precipitation(0, Application.Symbol_Millimeters, Application.Units_Millimeters, null),
            new Precipitation(1, Application.Symbol_Centimeters, Application.Units_Centimeters, value => value * 0.1),
            new Precipitation(2, Application.Symbol_Inches, Application.Units_Inches, value => value * 0.039370)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Precipitation From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Precipitation(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}