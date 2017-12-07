using System;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ShortTimeConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ShortTimeConverter() : base(Xameteo.Localization.ShortTime)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ShortDateConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ShortDateConverter() : base(Xameteo.Localization.ShortDate)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LongDateConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public LongDateConverter() : base(Xameteo.Localization.LongDate)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ShortDateTimeConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ShortDateTimeConverter() : base(Xameteo.Localization.ShortDateTime)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LongDateTimeConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public LongDateTimeConverter() : base(Xameteo.Localization.LongDateTime)
        {
        }
    }
}