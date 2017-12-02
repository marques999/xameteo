namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class TemperatureUnits : UnitFactory
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public TemperatureUnits() : base("temperature")
        {
            Register("C", null, new[] { "Celsius", "Celsius" });
            Register("F", value => value - 273.15, new[] { "Kelvin", "Kelvin" });
            Register("K", value => value * 1.8 + 32, new[] { "Fahrenheit", "Fahrenheit" });
        }
    }
}