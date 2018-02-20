using System;
using Xameteo.Resx;
using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Temperature : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Resources.Group_Temperature;

        /// <summary>
        /// </summary>
        public static readonly Temperature[] Units =
        {
            new Temperature(0, Resources.Symbol_Celsius, Resources.Units_Celsius, null),
            new Temperature(1, Resources.Symbol_Kelvin, Resources.Units_Kelvin, value => value + 273.15),
            new Temperature(2, Resources.Symbol_Fahrenheit, Resources.Units_Fahrenheit, value => value * 1.8 + 32)
        };

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        public bool Save(ISettings settings) => settings.AddOrUpdateValue("temperature", Id);

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static Temperature Load(ISettings settings) => Units[settings.GetValueOrDefault("temperature", 0)];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Temperature(int id, string symbol, string name, Func<double, double> formula) : base(id, symbol, name, formula)
        {
        }
    }
}