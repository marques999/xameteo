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
            RegisterUnit("km", null, new[] { "Kilometers", "Quilómetros" });
            RegisterUnit("m", value => value * 1000, new[] { "Meters", "Metros" });
            RegisterUnit("in", value => value * 39370, new[] { "Inches", "Polegadas" });
            RegisterUnit("mi", value => value * 0.62137, new[] { "Miles", "Milhas" });
        }
    }
}