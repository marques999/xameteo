using Xameteo.Resx;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// </summary>
        [JsonProperty("code")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableItem GenerateTable() => new TableItem(
            Resources.Forecast_Condition,
            Xameteo.Localization.GetCondition(Id)
        );
    }
}