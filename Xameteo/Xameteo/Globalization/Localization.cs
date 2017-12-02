using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    internal class Localization
    {
        /// <summary>
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("name")]
        public List<string> Localizations
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string Localize(Locale locale) => (int)locale < Localizations.Count ? Localizations[(int)locale] : Localizations[0];
    }
}