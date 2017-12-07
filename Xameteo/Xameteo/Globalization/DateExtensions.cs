using System;
using System.Globalization;

using Xamarin.Forms;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public delegate string DateTimeDelegate(DateTime dateTime, CultureInfo culture);

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class AbstractDateTimeConverter : IValueConverter
    {
        /// <summary>
        /// </summary>
        private readonly DateTimeDelegate _dateTimeDelegate;

        /// <summary>
        /// </summary>
        /// <param name="dateTimeDelegate"></param>
        protected AbstractDateTimeConverter(DateTimeDelegate dateTimeDelegate)
        {
            _dateTimeDelegate = dateTimeDelegate;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is DateTime dateTime ? _dateTimeDelegate(dateTime, culture) : "N/A";
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Now;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ShortTimeConverter : AbstractDateTimeConverter
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
    public class ShortDateConverter : AbstractDateTimeConverter
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
    public class LongDateConverter : AbstractDateTimeConverter
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
    public class ShortDateTimeConverter : AbstractDateTimeConverter
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
    public class LongDateTimeConverter : AbstractDateTimeConverter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public LongDateTimeConverter() : base(Xameteo.Localization.LongDateTime)
        {
        }
    }
}