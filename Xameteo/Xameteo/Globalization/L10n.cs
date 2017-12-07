using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

using Xamarin.Forms;
using Xameteo.Model;
using Application = Xameteo.Resx.Application;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    internal class L10N
    {
        /// <summary>
        /// </summary>
        private const string ResourceId = "Xameteo.Resx.Application";

        /// <summary>
        /// </summary>
        private readonly CultureInfo _cultureInfo = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        private readonly ResourceManager _resourceManager = new ResourceManager(ResourceId, typeof(L10N).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _resourceManager.GetString(key, _cultureInfo) ?? key;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public string GetOrDefault(string key, string fallback)
        {
            return _resourceManager.GetString(key, _cultureInfo) ?? fallback;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string Boolean(bool value, CultureInfo cultureInfo = null)
        {
            return value ? Application.Global_Yes : Application.Global_No;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string ShortCompass(string value, CultureInfo cultureInfo = null)
        {
            return Compass.TryGet(value, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string LongCompass(string value, CultureInfo cultureInfo = null)
        {
            return Compass.TryGet(value, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string ShortTime(DateTime dateTime, CultureInfo cultureInfo = null)
        {
            return dateTime.ToString("t", (cultureInfo ?? _cultureInfo).DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string ShortDate(DateTime dateTime, CultureInfo cultureInfo = null)
        {
            return dateTime.ToString("d", (cultureInfo ?? _cultureInfo).DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string LongDate(DateTime dateTime, CultureInfo cultureInfo = null)
        {
            return dateTime.ToString("D", (cultureInfo ?? _cultureInfo).DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string ShortDateTime(DateTime dateTime, CultureInfo cultureInfo = null)
        {
            return dateTime.ToString("g", (cultureInfo ?? _cultureInfo).DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string LongDateTime(DateTime value, CultureInfo cultureInfo = null)
        {
            return value.ToString("f", (cultureInfo ?? _cultureInfo).DateTimeFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string Percentage(double value, CultureInfo cultureInfo = null)
        {
            return (value / 100).ToString("P0", (cultureInfo ?? _cultureInfo).NumberFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string FixedPoint(double value, CultureInfo cultureInfo = null)
        {
            return value.ToString("F2", (cultureInfo ?? _cultureInfo).NumberFormat);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string Degrees(double value, CultureInfo cultureInfo = null)
        {
            return value.ToString("N0", (cultureInfo ?? _cultureInfo).NumberFormat) + " " + Application.Symbol_Degrees;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string GetCondition(int condition)
        {
            return _resourceManager.GetString("CONDITION_" + condition, _cultureInfo) ?? condition.ToString();
        }
    }
}