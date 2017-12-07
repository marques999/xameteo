using Xameteo.Resx;
using System.Collections.Generic;


namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal class Compass
    {
        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// </summary>
        private static readonly Dictionary<string, Compass> Points = new Dictionary<string, Compass>
        {
            { "N",  new Compass(Application.Symbol_N, Application.Compass_N) },
            { "S",  new Compass(Application.Symbol_S, Application.Compass_S) },
            { "E",  new Compass(Application.Symbol_E, Application.Compass_E) },
            { "W",  new Compass(Application.Symbol_W, Application.Compass_W) },
            { "NW",  new Compass(Application.Symbol_NW, Application.Compass_NW) },
            { "SW",  new Compass(Application.Symbol_SW, Application.Compass_SW) },
            { "NE",  new Compass(Application.Symbol_NE, Application.Compass_NE) },
            { "SE",  new Compass(Application.Symbol_SE, Application.Compass_SE) },
            { "NNW",  new Compass(Application.Symbol_NNW, Application.Compass_NNW) },
            { "WNW",  new Compass(Application.Symbol_WNW, Application.Compass_WNW) },
            { "SSW",  new Compass(Application.Symbol_SSW, Application.Compass_SSW) },
            { "WSW",  new Compass(Application.Symbol_WSW, Application.Compass_WSW) },
            { "NNE",  new Compass(Application.Symbol_NNE, Application.Compass_NNE) },
            { "ENE",  new Compass(Application.Symbol_ENE, Application.Compass_ENE) },
            { "SSE",  new Compass(Application.Symbol_SSE, Application.Compass_SSE) },
            { "ESE",  new Compass(Application.Symbol_ESE, Application.Compass_ESE) },
        };

        /// <summary>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="name"></param>
        private Compass(string symbol, string name)
        {
            Name = name;
            Symbol = symbol;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="shortCompass"></param>
        /// <returns></returns>
        public static string TryGet(string key, bool shortCompass)
        {
            return Points.TryGetValue(key, out var compass) ? (shortCompass ? compass.Symbol : compass.Name) : "N/A";
        }
    }
}