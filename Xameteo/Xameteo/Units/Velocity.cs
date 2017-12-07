using Xameteo.Resx;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Velocity : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Application.Group_Velocity;

        /// <summary>
        /// </summary>
        public static readonly Velocity[] Units =
        {
            new Velocity(0, Application.Symbol_Kilometers_Hour, Application.Units_Kilometers_Hour, null),
            new Velocity(1, Application.Symbol_Knots, Application.Units_Knots, value => value * 0.53996),
            new Velocity(2, Application.Symbol_Miles_Hour, Application.Units_Miles_Hour, value => value * 0.621388),
            new Velocity(3, Application.Symbol_Meters_Second, Application.Units_Meters_Second, value => value * 0.277777)
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Velocity From(int index) => index < Units.Length ? Units[index] : Units[0];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Velocity(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}