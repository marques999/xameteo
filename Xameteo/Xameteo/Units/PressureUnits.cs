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
            Register("mbar", null, new[] { "Millibar", "Milibares" });
            Register("kPA", value => value * 0.1, new[] { "Kilopascal", "Quilopascal" });
            Register("torr", value => value * 0.75006375541921, new[] { "Torr (mmHg)", "Torr (mmHg)" });
            Register("atm", value => value * 0.00098692326671601, new[] { "Atmosphere", "Atmosferas" });
        }
    }
}