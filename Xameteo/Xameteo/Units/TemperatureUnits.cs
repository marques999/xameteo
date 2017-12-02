using Xameteo.Model;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TemperatureUnits : UnitFactory
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public TemperatureUnits() : base("temperature")
        {
            RegisterUnit("C", null, new[] { "Celsius", "Celsius" });
            RegisterUnit("F", value => value - 273.15, new[] { "Kelvin", "Kelvin" });
            RegisterUnit("K", value => value * 1.8 + 32, new[] { "Fahrenheit", "Fahrenheit" });
        }
    }
}