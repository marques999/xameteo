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
        public ShortTimeConverter() : base(XameteoL10N.ShortTime)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class WeekdayConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public WeekdayConverter() : base(XameteoL10N.WeekDay)
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
        public LongDateTimeConverter() : base(XameteoL10N.LongDateTime)
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
        public ShortDateTimeConverter() : base(XameteoL10N.ShortDateTime)
        {
        }
    }
}