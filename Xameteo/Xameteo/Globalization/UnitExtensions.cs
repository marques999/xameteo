namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PressureConverter : UnitConverter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        protected override string Delegate(double unit) => XameteoApp.Instance.Pressure.Convert(unit);
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TemperatureConverter : UnitConverter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        protected override string Delegate(double unit) => XameteoApp.Instance.Temperature.Convert(unit);
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class VelocityConverter : UnitConverter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        protected override string Delegate(double unit) => XameteoApp.Instance.Velocity.Convert(unit);
    }
}