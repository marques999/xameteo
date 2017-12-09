using Xameteo.Resx;
using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Pressure : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Resources.Group_Pressure;

        /// <summary>
        /// </summary>
        public static readonly Pressure[] Units =
        {
            new Pressure(0, Resources.Symbol_Millibars, Resources.Units_Millibars, null),
            new Pressure(1, Resources.Symbol_Kilopascal, Resources.Units_Kilopascal, value => value * 0.1),
            new Pressure(2, Resources.Symbol_Torr, Resources.Units_Torr, value => value * 0.75006375541921),
            new Pressure(3, Resources.Symbol_Atmosphere, Resources.Units_Atmosphere, value => value * 0.00098692326671601)
        };

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        public bool Save(ISettings settings) => settings.AddOrUpdateValue("pressure", Id);

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static Pressure Load(ISettings settings) => Units[settings.GetValueOrDefault("pressure", 0)];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Pressure(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}