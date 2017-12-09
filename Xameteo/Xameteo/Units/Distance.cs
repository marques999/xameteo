using Xameteo.Resx;
using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Distance : Unit
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Type => Resources.Group_Distance;

        /// <summary>
        /// </summary>
        public static readonly Distance[] Units =
        {
            new Distance(0, Resources.Symbol_Kilometers, Resources.Units_Kilometers, null),
            new Distance(1, Resources.Symbol_Meters, Resources.Units_Meters, value => value * 1000),
            new Distance(2, Resources.Symbol_Inches, Resources.Units_Inches, value => value * 39370),
            new Distance(3, Resources.Symbol_Miles, Resources.Units_Miles, value => value * 0.62137)
        };

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        public bool Save(ISettings settings) => settings.AddOrUpdateValue("distance", Id);

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static Distance Load(ISettings settings) => Units[settings.GetValueOrDefault("distance", 0)];

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Distance(int id, string symbol, string name, FormulaDelegate formula) : base(id, symbol, name, formula)
        {
        }
    }
}