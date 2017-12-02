using Newtonsoft.Json;

namespace Xameteo.Adapters
{
    /// <summary>
    /// </summary>
    internal abstract class ApixuAdapter
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
        protected ApixuAdapter(string parameters)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Parameters.GetHashCode();
    }
}