using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            try
            {
                var changePage = true;
                var page = (Page)Activator.CreateInstance(item.TargetType);

                if (page is LocationView placePage)
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
            catch (Exception exception)
            {
                await Xameteo.Dialogs.Alert(exception);
            }
        }
    }
}