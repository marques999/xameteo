using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

using Xamarin.Forms;
using Xameteo.Model;

using Condition = Xameteo.Model.Condition;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    public interface ILocale
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        CultureInfo GetCurrentCultureInfo();
    }

    /// <summary>
    /// </summary>
    public static class XameteoL10N
    {
        /// <summary>
        /// </summary>
        private static readonly CultureInfo Culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        private static readonly ResourceManager Resources = new ResourceManager("Xameteo.Resx.Resources", typeof(XameteoL10N).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ParseTime(string dateTime)
        {
            try
            {
                return DateTime.ParseExact(dateTime, "hh:mm tt", Culture.DateTimeFormat);
            }
            catch (FormatException)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key) => Resources.GetString(key, Culture) ?? key;

        /// <summary>
        /// </summary>
        /// <param name="imageUri"></param>
        /// <returns></returns>
        public static ImageSource GetDrawable(string imageUri) => ImageSource.FromFile(
            Device.RuntimePlatform == Device.iOS ? "Images/" + imageUri : imageUri
        );

        /// <summary>
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static string LongCompass(int degrees) => $"{Compass.Get(degrees).Name} ({Degrees(degrees)})";
        public static string ShortCompass(int degrees) => $"{Compass.Get(degrees).Symbol} ({Degrees(degrees)})";

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static string FormatNumber(double value, string format) => value.ToString(format, Culture.NumberFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static string FormatDate(DateTime value, string format) => value.ToString(format, Culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShortTime(DateTime value) => FormatDate(value, "t");
        public static string ShortDate(DateTime value) => FormatDate(value, "d");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string LongDate(DateTime value) => FormatDate(value, "D");
        public static string LongDateTime(DateTime value) => FormatDate(value, "f");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string WeekDay(DateTime value) => FormatDate(value, "dddd");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FixedPoint(double value) => FormatNumber(value, "N2");
        public static string Percentage(double value) => FormatNumber(value / 100, "P0");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Degrees(int value)
        {
            return FormatNumber(value, "N0") + " " + Resx.Resources.Symbol_Degrees;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string GetCondition(Condition condition)
        {
            return Resources.GetString("Condition_" + condition.Id, Culture) ?? condition.Description;
        }
    }
}