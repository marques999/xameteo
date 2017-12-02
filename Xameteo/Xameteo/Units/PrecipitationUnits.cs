namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class PrecipitationUnits : UnitFactory
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PrecipitationUnits() : base("precipitation")
        {
            Register("mm", null, new[] { "Milimeters", "Milímetros" });
            Register("cm", value => value * 0.1, new[] { "Centimeters", "Centímetros" });
            Register("in", value => value * 0.039370, new[] { "Inches", "Polegadas" });
        }
    }
}