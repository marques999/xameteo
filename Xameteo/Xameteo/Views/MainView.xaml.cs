using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

            XameteoApp.Instance.Events.SubscribeView(this, (sender, args) =>
            {
                Detail = new NavigationPage(new LocationView(args.Forecast));
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                if (!(args.SelectedItem is MainModel item))
                {
                    return;
                }

                if (item.ViewModel == null)
                {
                    ResetNavigation();
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                }
                else
                {
                    ResetNavigation();
                    Detail = new NavigationPage(new LocationView(item.ViewModel.Forecast));
                }
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
        }

        private void ResetNavigation()
        {
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}