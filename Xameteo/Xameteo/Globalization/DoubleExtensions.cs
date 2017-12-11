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
}