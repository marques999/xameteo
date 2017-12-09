using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xameteo.API;
using Xameteo.Views.Location;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView
    {
        /// <summary>
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            MessagingCenter.Subscribe<ContentPage, ApixuAdapter>(this, "insert_location", async (sender, args) =>
            {          
                var forecast = await Xameteo.Api.Forecast(args, 15);

                if (forecast != null)
                {
                    Detail = new NavigationPage(new LocationView(forecast));
                }

                Xameteo.MyPlaces.Insert(args);
            });

            MessagingCenter.Subscribe<ContentPage, ApixuAdapter>(this, "view_location", async(sender, args) =>
            {
                var forecast = await Xameteo.Api.Forecast(args, 15);

                if (forecast != null)
                {
                    Detail = new NavigationPage(new LocationView(forecast));
                }
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MainModel item))
            {
                return;
            }

            var changePage = false;
            var page = (Page) Activator.CreateInstance(item.TargetType);

            if (page is LocationView placePage)
            {
                try
                {
                    var forecast = await Xameteo.MyPlaces.Forecast(item.Id);

                    if (forecast != null)
                    {
                        changePage = true;
                        placePage.Initialize(forecast);
                    }
                }
                catch (Exception exception)
                {
                    await Xameteo.Dialogs.Alert(exception);
                }
            }
            else
            {
                changePage = true;
            }

            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;

            if (changePage)
            {
                Detail = new NavigationPage(page);
            }
        }
    }
}