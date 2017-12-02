using Xameteo.Model;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class PressureUnits : UnitFactory
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PressureUnits() : base("pressure")
        {
            RegisterUnit("mbar", null, new[] { "Millibar", "Milibares" });
            RegisterUnit("kPA", value => value * 0.1, new[] { "Kilopascal", "Quilopascal" });
            RegisterUnit("torr", value => value * 0.75006375541921, new[] { "Torr (mmHg)", "Torr (mmHg)" });
            RegisterUnit("atm", value => value * 0.00098692326671601, new[] { "Atmosphere", "Atmosferas" });
        }
    }
}