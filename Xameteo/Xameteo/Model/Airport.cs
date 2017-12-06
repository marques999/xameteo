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
            new Airport("FAO", "Aeroporto Internacional de Faro"),
            new Airport("FNC", "Aeroporto Internacional da Madeira Cristiano Ronaldo (Funchal)"),
            new Airport("HOR", "Aeroporto da Horta"),
            new Airport("LIS", "Aeroporto Humberto Delgado (Lisboa)"),
            new Airport("PDL", "Aeroporto João Paulo II (Ponta Delgada)"),
            new Airport("OPO", "Aeroporto Francisco Sá Carneiro"),
            new Airport("PXO", "Aeroporto do Porto Santo"),
            new Airport("SMA", "Aeroporto de Santa Maria"),
            new Airport("TER", "Aeroporto Internacional das Lajes (Terceira)")
        };

        /// <summary>
        /// 
        /// </summary>
        public string IataCode
        {
            get;
        }

        /// <summary>
        /// </summary>
        private readonly string _defaultValue;

        /// <summary>
        /// 
        /// </summary>
        public string Name => Xameteo.Localization.GetOrDefault("AIRPORT_" + IataCode, _defaultValue);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Airport(string iataCode, string defaultValue)
        {
            IataCode = iataCode;
            _defaultValue = defaultValue;
        }
    }
}