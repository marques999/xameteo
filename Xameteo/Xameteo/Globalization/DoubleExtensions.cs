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
        public DegreesConverter() : base(XameteoL10N.Degrees)
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
        public FixedPointConverter() : base(XameteoL10N.FixedPoint)
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
        public PercentageConverter() : base(XameteoL10N.Percentage)
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
        public DistanceConverter() : base(XameteoApp.Instance.Distance.Convert)
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
        public PrecipitationConverter() : base(XameteoApp.Instance.Precipitation.Convert)
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
        public PressureConverter() : base(XameteoApp.Instance.Pressure.Convert)
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
        public TemperatureConverter() : base(XameteoApp.Instance.Temperature.Convert)
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
        public VelocityConverter() : base(XameteoApp.Instance.Velocity.Convert)
        {
        }
    }
}