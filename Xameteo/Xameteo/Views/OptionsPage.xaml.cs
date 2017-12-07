using System;

using Xameteo.Units;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsPage
    {
        /// <summary>
        /// </summary>
        public OptionsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public string TemperatureUnits
        {
            get => Xameteo.Settings.Temperature.Name;
            set => OnPropertyChanged(nameof(TemperatureUnits));
        }

        /// <summary>
        /// </summary>
        public string PressureUnits
        {
            get => Xameteo.Settings.Pressure.Name;
            set => OnPropertyChanged(nameof(PressureUnits));
        }

        /// <summary>
        /// </summary>
        public string PrecipitationUnits
        {
            get => Xameteo.Settings.Precipitation.Name;
            set => OnPropertyChanged(nameof(PrecipitationUnits));
        }

        /// <summary>
        /// </summary>
        public string DistanceUnits
        {
            get => Xameteo.Settings.Distance.Name;
            set => OnPropertyChanged(nameof(DistanceUnits));
        }

        /// <summary>
        /// </summary>
        public string VelocityUnits
        {
            get => Xameteo.Settings.Velocity.Name;
            set => OnPropertyChanged(nameof(VelocityUnits));
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectTemperature(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Temperature.Units, temperatureChoice =>
            {
                TemperatureUnits = temperatureChoice.Name;
                Xameteo.Settings.Temperature = temperatureChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectPressure(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Pressure.Units, pressureChoice =>
            {
                PressureUnits = pressureChoice.Name;
                Xameteo.Settings.Pressure = pressureChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectPrecipitation(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Precipitation.Units, precipitationChoice =>
            {
                PrecipitationUnits = precipitationChoice.Name;
                Xameteo.Settings.Precipitation = precipitationChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectDistance(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Distance.Units, distanceChoice =>
            {
                VelocityUnits = distanceChoice.Name;
                Xameteo.Settings.Distance = distanceChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectVelocity(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Velocity.Units, velocityChoice =>
            {
                VelocityUnits = velocityChoice.Name;
                Xameteo.Settings.Velocity = velocityChoice;
            });
        }
    }
}