﻿using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using Xameteo.API;
using Xameteo.Resx;
using Xameteo.Views.Location;
using Xameteo.Views.Settings;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        public MainViewModel()
        {
            XameteoApp.Instance.Events.SubscribeUpdates(InsertLocation, RemoveLocation);
            InitializeView();
        }

        /// <summary>
        /// </summary>
        private async void InitializeView()
        {
            try
            {
                MenuItems.Add(_homePage);
                MenuItems.Add(_settingsPage);
                XameteoDialogs.ShowLoading();
                await XameteoApp.Instance.RefreshPlaces(0);
                XameteoDialogs.HideLoading();
            }
            catch (Exception exception)
            {
                XameteoDialogs.HideLoading();
                XameteoDialogs.Alert(exception);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="previousIndex"></param>
        /// <returns></returns>
        public MainModel RefreshView(int previousIndex)
        {
            try
            {
                MenuItems.Clear();
                MenuItems.Add(_homePage);
                MenuItems.Add(_settingsPage);
                XameteoApp.Instance.Places.ForEach(InsertLocation);
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }

            return MenuItems[previousIndex];
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
        /// <param name="place"></param>
        /// <returns></returns>
        public MainModel FindModel(ApixuPlace place)
        {
            return MenuItems.FirstOrDefault(it => it.ViewModel == place);
        }

        /// <summary>
        /// </summary>
        private readonly MainModel _settingsPage = new MainModel
        {
            ViewModel = null,
            TargetType = typeof(SettingsView),
            Title = Resources.Title_Preferences,
            Icon = ImageSource.FromFile("icon_settings.png")
        };

        /// <summary>
        /// </summary>
        private readonly MainModel _homePage = new MainModel
        {
            ViewModel = null,
            Title = Resources.Title_Home,
            TargetType = typeof(HomeView),
            Icon = ImageSource.FromFile("icon_home.png")
        };

        /// <summary>
        /// </summary>
        /// <param name="events"></param>
        /// <param name="viewModel"></param>
        public void InsertLocation(XameteoEvents events, ApixuPlace viewModel)
        {
            InsertLocation(viewModel);
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
                Icon = ImageSource.FromFile(viewModel.Adapter.Icon)
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
        /// <param name="events"></param>
        /// <param name="adapter"></param>
        public void RemoveLocation(XameteoEvents events, ApixuPlace adapter)
        {
            var previous = MenuItems.FirstOrDefault(it => it.ViewModel == adapter);

            if (previous != null)
            {
                MenuItems.Remove(previous);
            }
        }
    }
}