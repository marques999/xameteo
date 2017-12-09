using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xameteo.Helpers;
using Xameteo.Views.Location;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : IEventObject
    {
        /// <summary>
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            Xameteo.Events.SubscribeView(this, async (sender, args) =>
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
        /// <param name="args"></param>
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                if (!(args.SelectedItem is MainModel item))
                {
                    return;
                }

                if (item.Location == null)
                {
                    ResetNavigation();
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                }
                else
                {
                    var forecast = await Xameteo.Api.Forecast(item.Location, 15);

                    if (forecast != null)
                    {
                        ResetNavigation();
                        Detail = new NavigationPage(new LocationView(forecast));
                    }
                }
            }
            catch (Exception exception)
            {
                await Xameteo.Dialogs.Alert(exception);
            }
        }

        private void ResetNavigation()
        {
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}