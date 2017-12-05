using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xameteo.Model;

namespace Xameteo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacesPage : ContentPage
    {
        /// <summary>
        /// </summary>
        public ObservableCollection<ApixuCurrent> Items
        {
            get;
            set;
        } = new ObservableCollection<ApixuCurrent>();

        /// <summary>
        /// </summary>
        private readonly IProgressDialog _progressDialog = Xameteo.Dialogs.InfiniteProgress;

        /// <summary>
        /// </summary>
        public PlacesPage()
        {
            InitializeComponent();
            InitializeList();
        }

        /// <summary>
        /// </summary>
        private async void InitializeList()
        {
            _progressDialog.Show();
            (await Task.WhenAll(Xameteo.MyPlaces.Current()).ConfigureAwait(false)).ForEach(it => Items.Add(it));
            MyListView.ItemsSource = Items;
            _progressDialog.Hide();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is ApixuCurrent weather)
            {
                await DisplayAlert("Item Tapped", weather.Current.ToString(), "OK");
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}