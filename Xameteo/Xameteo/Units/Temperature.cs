using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Temperature : UnitFactory
    {
        /// <summary>
        /// </summary>
        public static Unit Celsius
        {
            get;
        } = new Unit("C", null, new[] { "Celsius", "Celsius" });

        /// <summary>
        /// </summary>
        public static Unit Farenheit
        {
            get;
        } = new Unit("F", value => value - 273.15, new[] { "Kelvin", "Kelvin" });

        /// <summary>
        /// </summary>
        public static Unit Kelvin
        {
            get;
        } = new Unit("K", value => value * 1.8 + 32, new[] { "Fahrenheit", "Fahrenheit" });

        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            Celsius, Farenheit, Kelvin
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Temperature(ISettings settings) : base("temperature", settings, Units)
        {
        }
    }
}