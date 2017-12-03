using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class Pressure : UnitFactory
    {
        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            new Unit("mbar", null, new[] { "Millibars", "Milibares" }),
            new Unit("kPA", value => value * 0.1, new[] { "Kilopascal", "Quilopascal" }),
            new Unit("torr", value => value * 0.75006375541921, new[] { "Torr (mmHg)", "Torr (mmHg)" }),
            new Unit("atm", value => value * 0.00098692326671601, new[] { "Atmosphere", "Atmosferas" })
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Pressure(ISettings settings) : base("pressure", settings, Units)
        {
        }
    }
}