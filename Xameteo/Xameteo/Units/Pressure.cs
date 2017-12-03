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
        public static Unit Millibars
        {
            get;
        } = new Unit("mbar", null, new[] { "Millibars", "Milibares" });

        /// <summary>
        /// </summary>
        public static Unit Kilopascal
        {
            get;
        } = new Unit("kPA", value => value * 0.1, new[] { "Kilopascal", "Quilopascal" });

        /// <summary>
        /// </summary>
        public static Unit Torr
        {
            get;
        } = new Unit("torr", value => value * 0.75006375541921, new[] { "Torr (mmHg)", "Torr (mmHg)" });

        /// <summary>
        /// </summary>
        public static Unit Atmosphere
        {
            get;
        } = new Unit("atm", value => value * 0.00098692326671601, new[] { "Atmosphere", "Atmosferas" });

        /// <summary>
        /// </summary>
        public static readonly Unit[] Units =
        {
            Millibars, Kilopascal, Torr, Atmosphere
        };

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Pressure(ISettings settings) : base("pressure", settings, Units)
        {
        }
    }
}