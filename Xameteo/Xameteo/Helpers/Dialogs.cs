using System;
using System.Threading.Tasks;

using Acr.UserDialogs;

using Xamarin.Forms;
using Xameteo.Units;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Dialogs
    {
        /// <summary>
        /// </summary>
        private readonly IUserDialogs _instance = UserDialogs.Instance;

        /// <summary>
        /// </summary>
        /// <param name="page"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Task Alert(Page page, Exception exception)
        {
            return _instance.AlertAsync(exception.Message, exception.GetType().Name);
        }

        /// <summary>
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public delegate Action SelectUnitCallback(Unit choice);

        /// <summary>
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public IDisposable SelectUnit(UnitFactory factory, SelectUnitCallback generator)
        {
            var locale = Xameteo.Settings.Locale;
            var configuration = new ActionSheetConfig();

            foreach (var unit in factory.Units)
            {
                configuration.Add($"{unit.Translate(locale)} ({unit.Name})", generator(unit));
            }

            configuration.Title = $"Select {factory.Type} units";
            configuration.SetCancel();
            configuration.UseBottomSheet = false;

            return _instance.ActionSheet(configuration);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IProgressDialog InfiniteProgress => _instance.Progress(new ProgressDialogConfig
        {
            AutoShow = true,
            IsDeterministic = false
        });
    }
}