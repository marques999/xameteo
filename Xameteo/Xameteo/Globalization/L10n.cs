using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Xameteo.Globalization
{
    //
    using DictionaryL10N = Dictionary<string, Localization>;

    //
    /// <summary>
    /// </summary>
    internal class L10N
    {
        /// <summary>
        /// </summary>
        private readonly Locale _locale;

        /// <summary>
        /// </summary>
        private readonly DictionaryL10N _resources;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private readonly DictionaryL10N _conditions;

        /// <summary>
        /// </summary>
        public DictionaryL10N Airports
        {
            get;
        }

        /// <summary>
        /// </summary>
        /// <param name="locale"></param>
        public L10N(Locale locale)
        {
            _locale = locale;
            Airports = ParseJson("Airports.json");
            _resources = ParseJson("Xameteo.json");
            _conditions = ParseJson("Conditions.json");
        }

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFile(string fileName)
        {
            var stream = typeof(L10N).GetTypeInfo().Assembly.GetManifestResourceStream("Xameteo.Assets." + fileName);

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static DictionaryL10N ParseJson(string fileName)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Localization>>(ReadFile(fileName)).ToDictionary(it => it.Id, it => it);
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _resources.TryGetValue(key, out var resource) ? resource.Localize(_locale) : key;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string GetCondition(int condition)
        {
            return _conditions.TryGetValue(condition.ToString(), out var resource) ? resource.Localize(_locale) : "N/A";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> EnumerateAirports() => Airports.ToDictionary(it => it.Key, it => it.Value.Localize(_locale));
    }
}