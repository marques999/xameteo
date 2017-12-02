using Xameteo.Model;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class DistanceUnits : UnitFactory
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DistanceUnits() : base("distance")
        {
            Register("km", null, new[] { "Kilometers", "Quilómetros" });
            Register("m", value => value * 1000, new[] { "Meters", "Metros" });
            Register("in", value => value * 39370, new[] { "Inches", "Polegadas" });
            Register("mi", value => value * 0.62137, new[] { "Miles", "Milhas" });
        }
    }
}