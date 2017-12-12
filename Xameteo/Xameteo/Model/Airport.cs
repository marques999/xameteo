using Xameteo.Resx;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Airport
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [JsonConstructor]
        public Airport(string code, string name)
        {
            Code = code;
            Name = name;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; }

        /// <summary>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// </summary>
        [JsonIgnore]
        public static readonly Airport[] Instances =
        {
            new Airport("FAO", Resources.Airport_FAO),
            new Airport("FNC", Resources.Airport_FNC),
            new Airport("HOR", Resources.Airport_HOR),
            new Airport("LIS", Resources.Airport_LIS),
            new Airport("PDL", Resources.Airport_PDL),
            new Airport("OPO", Resources.Airport_OPO),
            new Airport("PXO", Resources.Airport_PXO),
            new Airport("SMA", Resources.Airport_SMA),
            new Airport("TER", Resources.Airport_TER),
        };

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"[{Code}] {Name}";
    }
}