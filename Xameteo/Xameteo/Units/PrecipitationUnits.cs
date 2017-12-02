using Xameteo.Model;

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
            RegisterUnit("mm", null, new[] { "Milimeters", "Milímetros" });
            RegisterUnit("cm", value => value * 0.1, new[] { "Centimeters", "Centímetros" });
            RegisterUnit("in", value => value * 0.039370, new[] { "Inches", "Polegadas" });
        }
    }
}