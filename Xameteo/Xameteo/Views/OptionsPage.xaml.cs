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
            DistanceUnits.Text = Xameteo.Settings.Distance.Name;
            PrecipitationUnits.Text = Xameteo.Settings.Precipitation.Name;
            PressureUnits.Text = Xameteo.Settings.Pressure.Name;
            TemperatureUnits.Text = Xameteo.Settings.Temperature.Name;
            VelocityUnits.Text = Xameteo.Settings.Velocity.Name;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectTemperature(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Temperature.Units, userChoice =>
            {
                TemperatureUnits.Text = userChoice.Name;
                Xameteo.Settings.Temperature = userChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectPressure(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Pressure.Units, userChoice =>
            {
                PressureUnits.Text = userChoice.Name;
                Xameteo.Settings.Pressure = userChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectPrecipitation(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Precipitation.Units, userChoice =>
            {
                PrecipitationUnits.Text = userChoice.Name;
                Xameteo.Settings.Precipitation = userChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectDistance(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Distance.Units, userChoice =>
            {
                DistanceUnits.Text = userChoice.Name;
                Xameteo.Settings.Distance = userChoice;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectVelocity(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Velocity.Units, userChoice =>
            {
                VelocityUnits.Text = userChoice.Name;
                Xameteo.Settings.Velocity = userChoice;
            });
        }
    }
}