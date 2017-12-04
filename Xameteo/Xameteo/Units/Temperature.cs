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
        private static readonly Unit[] TemperatureUnits =
        {
            new Unit("C", null, new[] { "Celsius", "Celsius" }),
            new Unit("F", value => value - 273.15, new[] { "Kelvin", "Kelvin" }),
            new Unit("K", value => value * 1.8 + 32, new[] { "Fahrenheit", "Fahrenheit" })
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Temperature(ISettings settings) : base("temperature", settings, TemperatureUnits)
        {
        }
    }
}