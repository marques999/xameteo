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
        public static Unit Milimeters
        {
            get;
        } = new Unit("mm", null, new[] { "Milimeters", "Milímetros" });

        /// <summary>
        /// </summary>
        public static Unit Centimeters
        {
            get;
        } = new Unit("cm", value => value * 0.1, new[] { "Centimeters", "Centímetros" });

        /// <summary>
        /// </summary>
        public static Unit Inches
        {
            get;
        } = new Unit("in", value => value * 0.039370, new[] { "Inches", "Polegadas" });

        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            Milimeters, Centimeters, Inches
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Precipitation(ISettings settings) : base("precipitation", settings, Units)
        {
        }
    }
}