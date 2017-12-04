using System;
using System.ComponentModel;
using Xameteo.Units;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class OptionsPageViewModel : INotifyPropertyChanged
    {
        private string _temperature;
        private string _pressure;
        private string _precipitation;
        private string _distance;
        private string _velocity;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        public string Temperature
        {
            get => _temperature;
            set
            {
                _temperature = "Temperature: " + value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        public string Pressure
        {
            get => _pressure;
            set
            {
                _pressure = "Pressure: " + value;
                OnPropertyChanged(nameof(Pressure));
            }
        }

        public string Precipitation
        {
            get => _precipitation;
            set
            {
                _precipitation = "Precipitation: " + value;
                OnPropertyChanged(nameof(Precipitation));
            }
        }

        /// <summary>
        /// </summary>
        public string Distance
        {
            get => _distance;
            set
            {
                _distance =  "Distance: " + value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        /// <summary>
        /// </summary>
        public string Velocity
        {
            get => _velocity;
            set
            {
                _velocity = "Velocity: " + value;
                OnPropertyChanged(nameof(Velocity));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="distanceChoice"></param>
        /// <returns></returns>
        internal Action HandleDistance(Unit distanceChoice)
        {
            return () =>
            {
                Distance = distanceChoice.ToString(17);
                Xameteo.Settings.Distance.Current = distanceChoice;
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="precipitationChoice"></param>
        /// <returns></returns>
        internal Action HandleVelocity(Unit velocityChoice)
        {
            return () =>
            {
                Velocity = velocityChoice.ToString(17);;
                Xameteo.Settings.Velocity.Current = velocityChoice;
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="precipitationChoice"></param>
        /// <returns></returns>
        internal Action HandleTemperature(Unit temperatureChoice)
        {
            return () =>
            {
                Temperature = temperatureChoice.ToString(17);
                Xameteo.Settings.Temperature.Current = temperatureChoice;
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="precipitationChoice"></param>
        /// <returns></returns>
        internal Action HandlePressure(Unit pressureChoice)
        {
            return () =>
            {
                Pressure = pressureChoice.ToString(17);
                Xameteo.Settings.Pressure.Current = pressureChoice;
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="precipitationChoice"></param>
        /// <returns></returns>
        internal Action HandlePrecipitation(Unit precipitationChoice)
        {
            return () =>
            {
                Precipitation = precipitationChoice.ToString(17);
                Xameteo.Settings.Precipitation.Current = precipitationChoice;
            };
        }

        /// <summary>
        /// </summary>
        public OptionsPageViewModel()
        {
            Distance = Xameteo.Settings.Distance.Current.ToString(17);
            Precipitation = Xameteo.Settings.Precipitation.Current.ToString(17);
            Pressure = Xameteo.Settings.Pressure.Current.ToString(17);
            Temperature = Xameteo.Settings.Temperature.Current.ToString(17);
            Velocity = Xameteo.Settings.Velocity.Current.ToString(17);
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
