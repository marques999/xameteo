using System;
using System.Linq;
using System.Collections.ObjectModel;

using Acr.UserDialogs;

using Xameteo.Resx;
using Xameteo.Units;

namespace Xameteo.Views.Settings
{
    /// <summary>
    /// </summary>
    public class SettingsViewModel
    {
        /// <summary>
        /// </summary>
        public ObservableCollection<SettingsModel> Items
        {
            get;
        } = new ObservableCollection<SettingsModel>();

        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="callback"></param>
        private void InsertUnit(Unit unit, Action<SettingsModel> callback) => Items.Add(
            new SettingsModel(string.Format(Resources.Settings_Units, unit.Type), unit.ToString(), callback)
        );

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public static void PromptApixuKey(Action<PromptResult> callback) => Xameteo.Dialogs.Prompt(
            "Apixu API",
            "Please enter the assigned Apixu Weather API key. You can generate your by signing up for an account in the official website (https://www.apixu.com/signup.aspx)",
            Xameteo.Settings.ApixuKey, callback
        );

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public static void PromptGoogleKey(Action<PromptResult> callback) => Xameteo.Dialogs.Prompt(
            "Geocoding API",
            "Please enter the assigned Google Geocoding API key. You can generate your own using the Google Developer Console (https://console.developers.google.com/apis/credentials)",
            Xameteo.Settings.GoogleKey, callback
        );

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="units"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public static IDisposable SelectUnit<T>(T[] units, Action<T> generator) where T : Unit
        {
            return Xameteo.Dialogs.ActionSheet(units.Select(unit =>
                new ActionSheetOption(unit.ToString(), () => generator(unit))
            ).ToList(), string.Format(Resources.Settings_Units, units[0].Type));
        }

        /// <summary>
        /// </summary>
        public SettingsViewModel()
        {
            Items.Add(new SettingsModel(Resources.Settings_ApixuKey, Xameteo.Settings.ApixuKey, UpdateApixuKey));
            Items.Add(new SettingsModel(Resources.Settings_GoogleKey, Xameteo.Settings.GoogleKey, UpdateGoogleKey));
            InsertUnit(Xameteo.Settings.Distance, UpdateDistance);
            InsertUnit(Xameteo.Settings.Precipitation, UpdatePrecipitation);
            InsertUnit(Xameteo.Settings.Pressure, UpdatePressure);
            InsertUnit(Xameteo.Settings.Temperature, UpdateTemperature);
            InsertUnit(Xameteo.Settings.Velocity, UpdateVelocity);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private void UpdateApixuKey(SettingsModel source) => PromptApixuKey(result =>
        {
            var userChoice = result.Text.Trim();

            if (Xameteo.Dialogs.ValidatePrompt(result))
            {
                source.Value = userChoice;
                Xameteo.Settings.ApixuKey = userChoice;
            }
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        public void UpdateGoogleKey(SettingsModel source) => PromptGoogleKey(result =>
        {
            var userChoice = result.Text.Trim();

            if (Xameteo.Dialogs.ValidatePrompt(result))
            {
                source.Value = userChoice;
                Xameteo.Settings.GoogleKey = userChoice;
            }
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdateTemperature(SettingsModel source) => SelectUnit(Temperature.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Temperature = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdatePressure(SettingsModel source) => SelectUnit(Pressure.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Pressure = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdatePrecipitation(SettingsModel source) => SelectUnit(Precipitation.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Precipitation = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdateDistance(SettingsModel source) => SelectUnit(Distance.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Distance = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdateVelocity(SettingsModel source) => SelectUnit(Velocity.Units, result =>
        {
            source.Value = result.ToString();
            Xameteo.Settings.Velocity = result;
        });
    }
}