using System.ComponentModel;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayHourlyPage
    {
        /// <summary>
        /// </summary>
        public TodayHourlyPage()
        {
            InitializeComponent();
        }

        /*public async void GetWeather(object sender, EventArgs e)
        {
            //var progressDialog = Xameteo.Dialogs.InfiniteProgress;

            try
            {
                progressDialog.Show();
                var position = await Xameteo.MyLocation;
                //_viewModel.Text = (await Xameteo.Api.Current(new CoordinatesAdapter(position.Latitude, position.Longitude)).ConfigureAwait(false)).ToString();
                progressDialog.Hide();
            }
            catch (Exception exception)
            {
                progressDialog.Hide();
                await Xameteo.Dialogs.Alert(this, exception);
            }
        }*/
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
            _text = "Ola Kira!";
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