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
        public static Unit KilometersPerHour
        {
            get;
        } = new Unit("km/h", null, new[] { "Kilometers/hour", "Quilómetros/hora" });

        /// <summary>
        /// </summary>
        public static Unit Knots
        {
            get;
        } = new Unit("knot", value => value * 0.53996, new[] { "Knots", "Nós" });

        /// <summary>
        /// </summary>
        public static Unit MilesPerHour
        {
            get;
        } = new Unit("mph", value => value * 0.621388, new[] { "Miles/hour", "Milhas/hora" });

        /// <summary>
        /// </summary>
        public static Unit MetersPerSecond
        {
            get;
        } = new Unit("m/s", value => value * 0.277777, new[] { "Meters/second", "Metros/segundo" });

        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            KilometersPerHour, Knots, MilesPerHour, MetersPerSecond
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Velocity(ISettings settings) : base("velocity", settings, Units)
        {
        }
    }
}