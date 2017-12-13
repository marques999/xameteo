﻿namespace Xameteo.Globalization
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
}