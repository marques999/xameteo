using Plugin.Settings.Abstractions;

namespace Xameteo.Units
{
    /// <summary>
    /// </summary>
    internal class ClockFactory
    {
        /// <summary>
        /// </summary>
        private readonly ISettings _settings;

        /// <summary>
        /// </summary>
        public static readonly Clock[] Clocks =
        {
            new Clock(0, "HH:mm", new[] { "24-hour", "24 horas" }),
            new Clock(1, "h:mm tt", new[] { "12-hour (AM/PM)", "12 horas (AM/PM)" })
        };

        /// <summary>
        /// </summary>
        public Clock Current
        {
            get
            {
                try
                {
                    return Clocks[_settings.GetValueOrDefault("clock", Clocks[0].Id)];
                }
                catch
                {
                    return Clocks[0];
                }
            }
            set
            {
                if (value.Id < Clocks.Length)
                {
                    _settings.AddOrUpdateValue("clock", Current.ToString());
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        public ClockFactory(ISettings settings)
        {
            _settings = settings;
        }
    }
}