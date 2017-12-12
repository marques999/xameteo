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
    public class ShortDateConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ShortDateConverter() : base(XameteoL10N.ShortDate)
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
        public LongDateConverter() : base(XameteoL10N.LongDate)
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
}