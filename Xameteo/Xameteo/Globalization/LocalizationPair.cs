namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    internal class LocalizationPair
    {
        /// <summary>
        /// </summary>
        public string Id
        {
            get;
        }

        /// <summary>
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public LocalizationPair(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}