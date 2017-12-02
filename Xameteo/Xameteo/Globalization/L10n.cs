using System.Resources;
using System.Reflection;
using System.Globalization;

using Xameteo.Constants;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    public class L10N
    {
        /// <summary>
        /// </summary>
        private readonly CultureInfo _locale;

        /// <summary>
        /// </summary>
        /// <param name="languageCulture"></param>
        public L10N(string languageCulture)
        {
            _locale = new CultureInfo(languageCulture);
        }

        /// <summary>
        /// </summary>
        public ResourceManager ResourceManager
        {
            get;
        } = new ResourceManager("Xameteo.Resx.Xameteo", typeof(L10N).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key) => ResourceManager.GetString(key, _locale) ?? key;

        /// <summary>
        /// </summary>
        /// <param name="weatherCondition"></param>
        /// <returns></returns>
        public string GetCondition(int weatherCondition) => Get("condition_" + weatherCondition);

        /// <summary>
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public string GetAirport(Airports airport) => Get("airport_" + airport.ToString().ToUpper());
    }
}