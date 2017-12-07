using Xameteo.Resx;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// </summary>
        public static readonly Airport[] Airports =
        {
            new Airport("FAO", Application.Airport_Fao),
            new Airport("FNC", Application.Airport_Fnc),
            new Airport("HOR", Application.Airport_Hor),
            new Airport("LIS", Application.Airport_Lis),
            new Airport("PDL", Application.Airport_Pdl),
            new Airport("OPO", Application.Airport_Opo),
            new Airport("PXO", Application.Airport_Pxo),
            new Airport("SMA", Application.Airport_Sma),
            new Airport("TER", Application.Airport_Ter),
        };

        /// <summary>
        /// </summary>
        public string Code
        {
            get;
        }

        /// <summary>
        /// </summary>
        public string Name
        {
            get;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Airport(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}