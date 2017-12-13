﻿using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewMaster
    {
        /// <summary>
        /// </summary>
        public ListView ListView;

        /// <summary>
        /// </summary>
        public MainViewMaster()
        {
            InitializeComponent();
            InitializeView(new MainViewModel());
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        private void InitializeView(MainViewModel viewModel)
        {
            BindingContext = viewModel;
            ListView = MenuItemsListView;
        }
    }
}