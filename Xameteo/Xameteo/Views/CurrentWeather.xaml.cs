using System;
using System.ComponentModel;

using Xamarin.Forms.Xaml;
using Xameteo.Adapters;

namespace Xameteo
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentWeather
    {
        /// <summary>
        /// </summary>
        public CurrentWeather()
        {
            _viewModel = new CurrentWeatherViewModel();
            BindingContext = _viewModel;
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        private readonly CurrentWeatherViewModel _viewModel;

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void GetWeather(object sender, EventArgs e)
        {
            /*var locations = Xameteo.Places.Get();

            if (locations.Count > 0)
            {
                _viewModel.Text = (await Xameteo.Weather(locations[0]).Current()).ToString();
            }      */

            try
            {
                var position = await Xameteo.MyLocation;
                _viewModel.Text = (await Xameteo.Weather(new CoordinatesAdapter(position.Latitude, position.Longitude)).Current()).ToString();
            }
            catch (Exception exception)
            {
                _viewModel.Text = exception.Message;
            } 
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class CurrentWeatherViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        private string _text;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        public string Text
        {
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
            get
            {
                return _text;
            }
        }

        /// <summary>
        /// </summary>
        public CurrentWeatherViewModel()
        {
            //_text = "Ola Kira!";
            _text = Xameteo.Settings.Language;
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