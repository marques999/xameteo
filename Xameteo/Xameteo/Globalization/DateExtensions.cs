using System;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TimeConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public TimeConverter() : base(XameteoL10N.ShortTime)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class DateConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DateConverter() : base(XameteoL10N.LongDate)
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
    public class DateTimeConverter : AbstractConverter<DateTime>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DateTimeConverter() : base(XameteoL10N.ShortDateTime)
        {
        }
    }
}