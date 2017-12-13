﻿using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms.Internals;

using Xameteo.API;
using Xameteo.Resx;
using Xameteo.Globalization;
using Xameteo.Views.Location;
using Xameteo.Views.Settings;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    internal class MainViewModel : IEventObject, INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        public MainViewModel()
        {
            InitializeView();
            XameteoApp.Instance.Events.SubscribeUpdates(this, InsertLocation, RemoveLocation);
        }

        /// <summary>
        /// </summary>
        private async void InitializeView()
        {
            try
            {
                MenuItems.Add(_homePage);
                XameteoDialogs.ShowLoading();
                await XameteoApp.Instance.RefreshPlaces();
                XameteoApp.Instance.Places.ForEach(InsertLocation);
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
            finally
            {
                MenuItems.Add(_settingsPage);
                XameteoDialogs.HideLoading();
            }
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<MainModel> MenuItems
        {
            get;
            set;
        } = new ObservableCollection<MainModel>();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        private readonly MainModel _settingsPage = new MainModel
        {
            ViewModel = null,
            TargetType = typeof(SettingsView),
            Title = Resources.Title_Preferences,
            Icon = XameteoL10N.GetDrawable("icon_settings.png")
        };

        /// <summary>
        /// </summary>
        private readonly MainModel _homePage = new MainModel
        {
            ViewModel = null,
            Title = Resources.Title_Home,
            TargetType = typeof(HomeView),
            Icon = XameteoL10N.GetDrawable("icon_home.png")
        };

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="adapter"></param>
        public void InsertLocation(IEventObject sender, ApixuPlace adapter)
        {
            InsertLocation(adapter);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        public void InsertLocation(ApixuPlace viewModel)
        {
            MenuItems.Add(new MainModel
            {
                ViewModel = viewModel,
                TargetType = typeof(LocationView),
                Title = viewModel.Forecast.Location.Formatted,
                Icon = XameteoL10N.GetDrawable(viewModel.Adapter.Icon)
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="adapter"></param>
        public void RemoveLocation(IEventObject source, ApixuPlace adapter)
        {
            var previous = MenuItems.FirstOrDefault(it => it.ViewModel == adapter);

            if (previous != null)
            {
                MenuItems.Remove(previous);
            }
        }
    }
}