using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

using Xameteo.Resx;
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
    public class Localization
    {
        /// <summary>
        /// </summary>
        private readonly CultureInfo _culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        private readonly ResourceManager _resources = new ResourceManager("Xameteo.Resx.Resources", typeof(Localization).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime ParseTime(string dateTime)
        {
            try
            {
                return DateTime.ParseExact(dateTime, "hh:mm tt", _culture.DateTimeFormat);
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
        public string Get(string key) => _resources.GetString(key, _culture) ?? key;

        /// <summary>
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public string LongCompass(int degrees) => $"{Compass.Get(degrees).Name} ({Degrees(degrees)})";
        public string ShortCompass(int degrees) => $"{Compass.Get(degrees).Symbol} ({Degrees(degrees)})";

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private string FormatNumber(double value, string format) => value.ToString(format, _culture.NumberFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private string FormatDate(DateTime value, string format) => value.ToString(format, _culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortTime(DateTime value) => FormatDate(value, "t");
        public string ShortDate(DateTime value) => FormatDate(value, "d");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string LongDate(DateTime value) => FormatDate(value, "D");
        public string LongDateTime(DateTime value) => FormatDate(value, "f");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string WeekDay(DateTime value) => FormatDate(value, "dddd");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string FixedPoint(double value) => FormatNumber(value, "N2");
        public string Percentage(double value) => FormatNumber(value / 100, "P0");

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Degrees(int value)
        {
            return FormatNumber(value, "N0") + " " + Resources.Symbol_Degrees;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string GetCondition(Condition condition)
        {
            return _resources.GetString("Condition_" + condition.Id, _culture) ?? condition.Description;
        }
    }
}