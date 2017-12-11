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
        private static readonly List<Compass> Instances = new List<Compass>
        {
            new Compass(Resources.Symbol_N, Resources.Compass_N),
            new Compass(Resources.Symbol_NNE, Resources.Compass_NNE),
            new Compass(Resources.Symbol_NE, Resources.Compass_NE),
            new Compass(Resources.Symbol_ENE, Resources.Compass_ENE),
            new Compass(Resources.Symbol_E, Resources.Compass_E),
            new Compass(Resources.Symbol_ESE, Resources.Compass_ESE),
            new Compass(Resources.Symbol_SE, Resources.Compass_SE),
            new Compass(Resources.Symbol_SSE, Resources.Compass_SSE),
            new Compass(Resources.Symbol_S, Resources.Compass_S),
            new Compass(Resources.Symbol_SSW, Resources.Compass_SSW),
            new Compass(Resources.Symbol_SW, Resources.Compass_SW),
            new Compass(Resources.Symbol_WSW, Resources.Compass_WSW),
            new Compass(Resources.Symbol_W, Resources.Compass_W),
            new Compass(Resources.Symbol_WNW, Resources.Compass_WNW),
            new Compass(Resources.Symbol_NW, Resources.Compass_NW) ,
            new Compass(Resources.Symbol_NNW, Resources.Compass_NNW)
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
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Compass Get(int degrees) => Instances[(int)((degrees + 11.25) / 22.5) % 16];
    }
}