using System;
using Xameteo.Resx;
using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Velocity : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Resources.Group_Velocity;

        /// <summary>
        /// </summary>
        public static readonly Velocity[] Units =
        {
            new Velocity(0, Resources.Symbol_Kilometers_Hour, Resources.Units_Kilometers_Hour, null),
            new Velocity(1, Resources.Symbol_Knots, Resources.Units_Knots, value => value * 0.53996),
            new Velocity(2, Resources.Symbol_Miles_Hour, Resources.Units_Miles_Hour, value => value * 0.621388),
            new Velocity(3, Resources.Symbol_Meters_Second, Resources.Units_Meters_Second, value => value * 0.277777)
        };

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        public bool Save(ISettings settings) => settings.AddOrUpdateValue("velocity", Id);

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static Velocity Load(ISettings settings) => Units[settings.GetValueOrDefault("velocity", 0)];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Velocity(int id, string symbol, string name, Func<double, double> formula) : base(id, symbol, name, formula)
        {
        }
    }
}