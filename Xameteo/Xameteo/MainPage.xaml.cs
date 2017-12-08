using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xameteo.Views;

namespace Xameteo
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        /// <summary>
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MainPageMenuItem item))
            {
                return;
            }

            var changePage = true;
            var page = (Page)Activator.CreateInstance(item.TargetType);

            if (page is PlacePage placePage)
            {
                try
                {
                    var forecast = await Xameteo.MyPlaces.Forecast(item.Id);

                    if (forecast == null)
                    {
                        changePage = false;
                    }
                    else
                    {
                        placePage.Title = forecast.Location.ToString();
                        placePage.Initialize(forecast);
                    }
                }
                catch (Exception exception)
                {
                    changePage = false;
                    await Xameteo.Dialogs.Alert(exception);
                }
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