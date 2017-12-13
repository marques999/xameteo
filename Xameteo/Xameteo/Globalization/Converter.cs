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
        private readonly Func<T, string> _function;

        /// <summary>
        /// </summary>
        /// <param name="function"></param>
        protected AbstractConverter(Func<T, string> function)
        {
            _function = function;
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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Prefix(value is T tvalue ? _function(tvalue) : "N/A", parameter);
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
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class UnitConverter : IValueConverter
    {
        /// <summary>
        /// </summary>
        protected abstract string Delegate(double unit);

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
            return value is double number ? Delegate(number) : "N/A";
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
    }
}