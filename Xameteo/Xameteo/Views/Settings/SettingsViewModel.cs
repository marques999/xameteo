using System;
using System.Collections.ObjectModel;

using Xameteo.Units;
using Acr.UserDialogs;

namespace Xameteo.Views.Settings
{
    /// <summary>
    /// </summary>
    public class SettingsViewModel
    {
        /// <summary>
        /// </summary>
        public ObservableCollection<SettingsModel> Items { get; } = new ObservableCollection<SettingsModel>();

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static bool ValidateResult(PromptResult result) => result.Ok && result.Text.Trim().Length > 0;

        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="callback"></param>
        private void InsertUnit(Unit unit, Action<SettingsModel> callback)
        {
            Items.Add(new SettingsModel(string.Format(Resx.Resources.Settings_Units, unit.Type), unit.ToString(), callback));
        }

        /// <summary>
        /// </summary>
        public SettingsViewModel()
        {
            Items.Add(new SettingsModel(Resx.Resources.Settings_ApixuKey, Xameteo.Settings.ApixuKey, UpdateApixuKey));
            Items.Add(new SettingsModel(Resx.Resources.Settings_GoogleKey, Xameteo.Settings.GoogleKey, UpdateGoogleKey));
            InsertUnit(Xameteo.Settings.Distance, UpdateDistance);
            InsertUnit(Xameteo.Settings.Precipitation, UpdatePrecipitation);
            InsertUnit(Xameteo.Settings.Pressure, UpdatePressure);
            InsertUnit(Xameteo.Settings.Temperature, UpdateTemperature);
            InsertUnit(Xameteo.Settings.Velocity, UpdateVelocity);
        }

        /// <summary>
        /// </summary>
        private static void UpdateApixuKey(SettingsModel source) => Xameteo.Dialogs.PromptApixuKey(result =>
        {
            var userChoice = result.Text.Trim();

            if (ValidateResult(result))
            {
                source.Value = userChoice;
                Xameteo.Settings.ApixuKey = userChoice;
            }
        });

        /// <summary>
        /// </summary>
        public static void UpdateGoogleKey(SettingsModel source) => Xameteo.Dialogs.PromptGoogleKey(result =>
        {
            var userChoice = result.Text.Trim();

            if (ValidateResult(result))
            {
                source.Value = userChoice;
                Xameteo.Settings.GoogleKey = userChoice;
            }
        });

        /// <summary>
        /// </summary>
        private static void UpdateTemperature(SettingsModel source) => Xameteo.Dialogs.SelectUnit(Temperature.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Temperature = result;
        });

        /// <summary>
        /// </summary>
        private static void UpdatePressure(SettingsModel source) => Xameteo.Dialogs.SelectUnit(Pressure.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Pressure = result;
        });

        /// <summary>
        /// </summary>
        private static void UpdatePrecipitation(SettingsModel source) => Xameteo.Dialogs.SelectUnit(Precipitation.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Precipitation = result;
        });

        /// <summary>
        /// </summary>
        private static void UpdateDistance(SettingsModel source) => Xameteo.Dialogs.SelectUnit(Distance.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Distance = result;
        });

        /// <summary>
        /// </summary>
        private static void UpdateVelocity(SettingsModel source) => Xameteo.Dialogs.SelectUnit(Velocity.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Velocity = result;
        });
    }
}