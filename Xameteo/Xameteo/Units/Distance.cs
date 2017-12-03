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
        public static Unit Kilometers
        {
            get;
        } = new Unit("km", null, new[] { "Kilometers", "Quilómetros" });

        /// <summary>
        /// </summary>
        public static Unit Meters
        {
            get;
        } = new Unit("m", value => value * 1000, new[] { "Meters", "Metros" });

        /// <summary>
        /// </summary>
        public static Unit Inches
        {
            get;
        } = new Unit("in", value => value * 39370, new[] { "Inches", "Polegadas" });

        /// <summary>
        /// </summary>
        public static Unit Miles
        {
            get;
        } = new Unit("mi", value => value * 0.62137, new[] { "Miles", "Milhas" });

        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            Kilometers, Meters, Inches, Miles
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Distance(ISettings settings) : base("distance", settings, Units)
        {
        }
    }
}