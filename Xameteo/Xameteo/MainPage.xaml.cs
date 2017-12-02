using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MainPageMenuItem item))
            {
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);

            page.Title = item.Title;
            Detail = new NavigationPage(page);
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}