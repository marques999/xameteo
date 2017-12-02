using Xameteo.Model;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class VelocityUnits : UnitFactory
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public VelocityUnits() : base("velocity")
        {
            RegisterUnit("knot", value => value * 0.53996, new[] { "Knots", "Nós" });
            RegisterUnit("km/h", null, new[] { "Kilometers/hour", "Quilómetros/hora" });
            RegisterUnit("mph", value => value * 0.621388, new[] { "Miles/hour", "Milhas/hora" });
            RegisterUnit("m/s", value => value * 0.277777, new[] { "Meters/second", "Metros/segundo" });
        }
    }
}