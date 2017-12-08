using System;
using System.Globalization;

using Xamarin.Forms;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class AbstractConverter<T> : IValueConverter
    {
        /// <summary>
        /// </summary>
        private readonly ConverterDelegate _converterDelegate;

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected delegate string ConverterDelegate(T type, CultureInfo culture);

        /// <summary>
        /// </summary>
        /// <param name="converterDelegate"></param>
        protected AbstractConverter(ConverterDelegate converterDelegate)
        {
            _converterDelegate = converterDelegate;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string Prefix(string value, object parameter)
        {
            return parameter is string prefix ? prefix + value : value;
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
            return value;
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
            return Prefix(value is T tvalue ? _converterDelegate(tvalue, culture) : "N/A", parameter);
        }
    }
}