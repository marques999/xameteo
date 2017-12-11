using Xameteo.Model;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentlyPage
    {
        /// <summary>
        /// </summary>
        public TableGroup Items { get; }

        /// <summary>
        /// </summary>
        public CurrentlyPage(ITableProvider current)
        {
            Items = current.GenerateTable();
            InitializeComponent();
            BindingContext = this;
        }
    }
}