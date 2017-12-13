using System.Collections.Generic;

using Xamarin.Forms;
using Xameteo.Model;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastPage
    {
        /// <summary>
        /// </summary>
        public List<ForecastDaily> Items { get; }

        /// <summary>
        /// </summary>
        public ForecastPage(Forecast forecast)
        {
            Items = forecast.Days;
            InitializeComponent();
            BindingContext = this;
        }

        private async void ShowModal(object sender, ItemTappedEventArgs e)
        {
            if ((sender as ListView)?.SelectedItem != null)
            {
                var detailPage = new HistoryPage(Items[0]);
                await Navigation.PushModalAsync(detailPage);
            }
        }
    }
}