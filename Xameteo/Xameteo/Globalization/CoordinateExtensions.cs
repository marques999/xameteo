using System;
using System.Globalization;

using Xamarin.Forms;
using Xameteo.Model;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    public class LatitudeConverter : IValueConverter
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string Prefix(string value, object parameter)
        {
            return parameter is string prefix ? prefix + value : value;
        }

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

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Prefix(value is Coordinates coordinates ? coordinates.StandardizeLatitude() : "N/A", parameter);
        }
    }

    /// <summary>
    /// </summary>
    public class LongitudeConverter : IValueConverter
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string Prefix(string value, object parameter)
        {
            return parameter is string prefix ? prefix + value : value;
        }

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

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Prefix(value is Coordinates coordinates ? coordinates.StandardizeLongitude() : "N/A", parameter);
        }
    }
}