using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Precipitation : UnitFactory
    {
        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            new Unit("mm", null, new[] { "Milimeters", "Milímetros" }),
            new Unit("cm", value => value * 0.1, new[] { "Centimeters", "Centímetros" }),
            new Unit("in", value => value * 0.039370, new[] { "Inches", "Polegadas" })
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Precipitation(ISettings settings) : base("precipitation", settings, Units)
        {
        }
    }
}