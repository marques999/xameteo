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
        /// <param name="args"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                if (args.SelectedItem is MainModel item)
                {
                    IsPresented = false;
                    Detail = new NavigationPage(item.ViewModel == null ? (Page)Activator.CreateInstance(item.TargetType) : new LocationView(item.ViewModel));
                }
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
        }
    }
}