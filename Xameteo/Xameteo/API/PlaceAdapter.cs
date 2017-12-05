using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public abstract class PlaceAdapter
    {
        /// <summary>
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        /// <param name="parameters"></param>
        protected PlaceAdapter(string parameters)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Parameters.GetHashCode();
    }
}