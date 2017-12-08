using Xameteo.Resx;
using System.Collections.Generic;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Compass
    {
        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// </summary>
        private static readonly Dictionary<string, Compass> Instances = new Dictionary<string, Compass>
        {
            { "N",  new Compass(Resources.Symbol_N, Resources.Compass_N) },
            { "S",  new Compass(Resources.Symbol_S, Resources.Compass_S) },
            { "E",  new Compass(Resources.Symbol_E, Resources.Compass_E) },
            { "W",  new Compass(Resources.Symbol_W, Resources.Compass_W) },
            { "NW",  new Compass(Resources.Symbol_NW, Resources.Compass_NW) },
            { "SW",  new Compass(Resources.Symbol_SW, Resources.Compass_SW) },
            { "NE",  new Compass(Resources.Symbol_NE, Resources.Compass_NE) },
            { "SE",  new Compass(Resources.Symbol_SE, Resources.Compass_SE) },
            { "NNW",  new Compass(Resources.Symbol_NNW, Resources.Compass_NNW) },
            { "WNW",  new Compass(Resources.Symbol_WNW, Resources.Compass_WNW) },
            { "SSW",  new Compass(Resources.Symbol_SSW, Resources.Compass_SSW) },
            { "WSW",  new Compass(Resources.Symbol_WSW, Resources.Compass_WSW) },
            { "NNE",  new Compass(Resources.Symbol_NNE, Resources.Compass_NNE) },
            { "ENE",  new Compass(Resources.Symbol_ENE, Resources.Compass_ENE) },
            { "SSE",  new Compass(Resources.Symbol_SSE, Resources.Compass_SSE) },
            { "ESE",  new Compass(Resources.Symbol_ESE, Resources.Compass_ESE) },
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
        /// <returns></returns>
        public static Compass Get(string key)
        {
            return Instances.TryGetValue(key, out var compass) ? compass : null;
        }
    }
}