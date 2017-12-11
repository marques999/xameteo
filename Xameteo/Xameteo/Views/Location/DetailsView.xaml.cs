using Xameteo.Model;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsView
    {
        /// <summary>
        /// </summary>
        public TableGroup Items { get; }

        /// <summary>
        /// </summary>
        /// <param name="location"></param>
        public DetailsView(ITableProvider location)
        {
            Items = location.GenerateTable();
            InitializeComponent();
            BindingContext = this;
        }
    }
}