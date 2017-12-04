using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsPage: ContentPage
    {
        /// <summary>
        /// </summary>
        public OptionsPage()
        {
            _viewModel = new OptionsPageViewModel();
            BindingContext = _viewModel;
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        private readonly OptionsPageViewModel _viewModel;

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectTemperature(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Xameteo.Settings.Temperature, _viewModel.HandleTemperature);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectPressure(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Xameteo.Settings.Pressure, _viewModel.HandlePressure);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectPrecipitation(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Xameteo.Settings.Precipitation, _viewModel.HandlePrecipitation);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectDistance(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Xameteo.Settings.Distance, _viewModel.HandleDistance);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectVelocity(object sender, EventArgs args)
        {
            Xameteo.Dialogs.SelectUnit(Xameteo.Settings.Velocity, _viewModel.HandleVelocity);
        }
    }
}