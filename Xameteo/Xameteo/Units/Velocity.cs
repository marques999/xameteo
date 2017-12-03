using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Velocity : UnitFactory
    {
        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            new Unit("km/h", null, new[] { "Kilometers/hour", "Quilómetros/hora" }),
            new Unit("knot", value => value * 0.53996, new[] { "Knots", "Nós" }),
            new Unit("mph", value => value * 0.621388, new[] { "Miles/hour", "Milhas/hora" }),
            new Unit("m/s", value => value * 0.277777, new[] { "Meters/second", "Metros/segundo" })
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Velocity(ISettings settings) : base("velocity", settings, Units)
        {
        }
    }
}