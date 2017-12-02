namespace Xameteo.Helpers
{
    internal class LocalizationPair
    {
        public string Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public LocalizationPair(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
