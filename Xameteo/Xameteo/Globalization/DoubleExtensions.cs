namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class DegreesConverter : AbstractConverter<int>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DegreesConverter() : base(Xameteo.Localization.Degrees)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class FixedPointConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public FixedPointConverter() : base(Xameteo.Localization.FixedPoint)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PercentageConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PercentageConverter() : base(Xameteo.Localization.Percentage)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class DistanceConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DistanceConverter() : base(Xameteo.Settings.Distance.Convert)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PrecipitationConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PrecipitationConverter() : base(Xameteo.Settings.Precipitation.Convert)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PressureConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PressureConverter() : base(Xameteo.Settings.Pressure.Convert)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TemperatureConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public TemperatureConverter() : base(Xameteo.Settings.Temperature.Convert)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class VelocityConverter : AbstractConverter<double>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public VelocityConverter() : base(Xameteo.Settings.Velocity.Convert)
        {
        }
    }
}