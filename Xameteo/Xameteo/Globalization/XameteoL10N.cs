using Xamarin.Forms;

using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

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
        private const string ResourceId = "Xameteo.Resx";

        /// <summary>
        /// </summary>
        private static readonly CultureInfo Culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        private static readonly ResourceManager Resources = new ResourceManager($"{ResourceId}.Resources", typeof(XameteoL10N).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ParseTime(string dateTime)
        {
            try
            {
                return DateTime.ParseExact(dateTime, "hh:mm tt", CultureInfo.InvariantCulture);
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
        public static string Get(string key)
        {
            return Resources.GetString(key, Culture) ?? key;
        }

        /// <summary>
        /// </summary>
        /// <param name="imageUri"></param>
        /// <returns></returns>
        public static string GetDrawable(string imageUri)
        {
            return $"{ResourceId}.{imageUri}";
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string LongCompass(int value)
        {
            return $"{Compass.Get(value).Name} ({Degrees(value)})";
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShortCompass(int value)
        {
            return $"{Compass.Get(value).Symbol} ({Degrees(value)})";
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string LongDate(DateTime value)
        {
            return value.ToString("D", Culture.DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShortTime(DateTime value)
        {
            return value.ToString("t", Culture.DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShortDateTime(DateTime value)
        {
            return value.ToString("G", Culture.DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OnlyHour(DateTime value)
        {
            return value.ToString("h tt", Culture.DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OnlyDayMonth(DateTime value)
        {
            return value.ToString("d/M", Culture.DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string WeekDay(DateTime value)
        {
            return value.ToString("dddd", Culture.DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Percentage(double value)
        {
            return (value / 100).ToString("P0", Culture.NumberFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Degrees(int value)
        {
            return value.ToString("N0", Culture.NumberFormat) + " " + Resx.Resources.Symbol_Degrees;
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