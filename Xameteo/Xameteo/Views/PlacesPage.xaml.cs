using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

using Xameteo.Model;

namespace Xameteo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacesPage
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
        public PlacesPage()
        {
            InitializeComponent();
            MyListView.ItemsSource = Items;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override async void OnAppearing()
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();
                (await Task.WhenAll(Xameteo.MyPlaces.Current())).ForEach(it => Items.Add(it));
                progressDialog.Hide();
            }
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