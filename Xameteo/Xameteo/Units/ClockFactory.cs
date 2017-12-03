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
            set => Update(value);
            get => Clocks[_settings.GetValueOrDefault("clock", 0)];
        }

        /// <summary>
        /// </summary>
        /// <param name="settings"></param>
        public ClockFactory(ISettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// </summary>
        private void Update(Clock clock)
        {
            if (clock.Id < Clocks.Length)
            {
                _settings.AddOrUpdateValue("clock", Current.Id);
            }
        }
    }
}