using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Distance : UnitFactory
    {
        /// <summary>
        /// </summary>
        public static readonly Unit[] DistanceUnits =
        {
            new Unit("km", null, new[] { "Kilometers", "Quilómetros" }),
            new Unit("m", value => value * 1000, new[] { "Meters", "Metros" }),
            new Unit("in", value => value * 39370, new[] { "Inches", "Polegadas" }),
            new Unit("mi", value => value * 0.62137, new[] { "Miles", "Milhas" })
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Distance(ISettings settings) : base("distance", settings, DistanceUnits)
        {
        }
    }
}