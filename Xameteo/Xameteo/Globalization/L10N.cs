using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

using Xamarin.Forms;

using Xameteo.Model;
using Xameteo.Resx;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    internal class L10N
    {
        /// <summary>
        /// </summary>
        private const string ResourceId = "Xameteo.Resx.Resources";

        /// <summary>
        /// </summary>
        private readonly CultureInfo _culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        private readonly ResourceManager _resources = new ResourceManager(ResourceId, typeof(L10N).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _resources.GetString(key, _culture) ?? key;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public string GetOrDefault(string key, string fallback)
        {
            return _resources.GetString(key, _culture) ?? fallback;
        }

        /// <summary>
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public string LongCompass(int degrees)
        {
            return $"{Compass.Get(degrees).Name} ({Degrees(degrees)})";
        }
        
        /// <summary>
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public string ShortCompass(int degrees)
        {
            return $"{Compass.Get(degrees).Symbol} ({Degrees(degrees)})";
        }

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
        /// <param name="value"></param>
        /// <returns></returns>
        public string Boolean(bool value) => value ? Resources.Global_Yes : Resources.Global_No;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortTime(DateTime value) => value.ToString("t", _culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortDate(DateTime value) => value.ToString("d", _culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string LongDate(DateTime value) => value.ToString("D", _culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortDateTime(DateTime value) => value.ToString("g", _culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string LongDateTime(DateTime value) => value.ToString("f", _culture.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Percentage(double value) => (value / 100).ToString("P0", _culture.NumberFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string FixedPoint(double value) => value.ToString("N2", _culture.NumberFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Degrees(int value)
        {
            return value.ToString("N0", _culture.NumberFormat) + " " + Resources.Symbol_Degrees;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string GetCondition(int condition)
        {
            return _resources.GetString("Condition_" + condition, _culture) ?? condition.ToString();
        }
    }
}