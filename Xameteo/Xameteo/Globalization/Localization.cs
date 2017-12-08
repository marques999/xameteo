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
    internal class Localization
    {
        /// <summary>
        /// </summary>
        private const string ResourceId = "Xameteo.Resx.Resources";

        /// <summary>
        /// </summary>
        private static readonly Assembly Assembly = typeof(Localization).GetTypeInfo().Assembly;

        /// <summary>
        /// </summary>
        private readonly ResourceManager _resources = new ResourceManager(ResourceId, Assembly);

        /// <summary>
        /// </summary>
        private readonly CultureInfo _cultureInfo = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _resources.GetString(key, _cultureInfo) ?? key;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public string GetOrDefault(string key, string fallback)
        {
            return _resources.GetString(key, _cultureInfo) ?? fallback;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string LongCompass(Compass value) => value?.Name ?? "N/A";

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortCompass(Compass value) => value?.Symbol ?? "N/A";

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Boolean(bool value) => value ? Resources.Global_Yes : Resources.Global_No;

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortTime(DateTime value) => value.ToString("t", _cultureInfo.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortDate(DateTime value) => value.ToString("d", _cultureInfo.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string LongDate(DateTime value) => value.ToString("D", _cultureInfo.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShortDateTime(DateTime value) => value.ToString("g", _cultureInfo.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string LongDateTime(DateTime value) => value.ToString("f", _cultureInfo.DateTimeFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Percentage(double value) => (value / 100).ToString("P0", _cultureInfo.NumberFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string FixedPoint(double value) => value.ToString("N2", _cultureInfo.NumberFormat);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Degrees(double value)
        {
            return value.ToString("N0", _cultureInfo.NumberFormat) + " " + Resources.Symbol_Degrees;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string GetCondition(int condition)
        {
            return _resources.GetString("Condition_" + condition, _cultureInfo) ?? condition.ToString();
        }
    }
}