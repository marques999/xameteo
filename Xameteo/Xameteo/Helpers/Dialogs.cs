using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xameteo.Resx;

using Acr.UserDialogs;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Dialogs
    {
        /// <summary>
        /// </summary>
        private readonly IUserDialogs _userDialogs = UserDialogs.Instance;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IProgressDialog InfiniteProgress => _userDialogs.Progress(new ProgressDialogConfig
        {
            AutoShow = true,
            IsDeterministic = false,
            Title = Resources.Loading_Title
        });

        /// <summary>
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Task Alert(Exception exception)
        {
            return _userDialogs.AlertAsync(exception.Message, exception.GetType().Name);
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool ValidatePrompt(PromptResult result) => result.Ok && result.Text.Trim().Length > 0;

        /// <summary>
        /// </summary>
        private readonly ActionSheetOption _actionSheetCancel = new ActionSheetOption(Resources.Button_Cancel);

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="placeholder"></param>
        /// <param name="callback"></param>
        public void Prompt(string title, string message, string placeholder, Action<PromptResult> callback) => _userDialogs.Prompt(new PromptConfig
        {
            Title = title,
            Message = message,
            OnAction = callback,
            IsCancellable = true,
            Text = placeholder,
            OkText = Resources.Button_OK,
            InputType = InputType.Default,
            CancelText = Resources.Button_Cancel
        });

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<bool> PromptYesNo(string title, string message) => _userDialogs.ConfirmAsync(new ConfirmConfig
        {
            Title = title,
            Message = message,
            OkText = Resources.Global_Yes,
            CancelText = Resources.Global_No
        });

        /// <summary>
        /// </summary>
        /// <param name="options"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public IDisposable ActionSheet(List<ActionSheetOption> options, string title) => _userDialogs.ActionSheet(new ActionSheetConfig
        {
            Title = title,
            Options = options,
            UseBottomSheet = false,
            Cancel = _actionSheetCancel,
        });

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public void PromptApixuKey(Action<PromptResult> callback) => Prompt(
            "Apixu API",
            "Please enter the assigned Apixu Weather API key. You can generate your by signing up for an account in the official website (https://www.apixu.com/signup.aspx)",
            Xameteo.Settings.ApixuKey,
            callback
        );

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public void PromptGoogleKey(Action<PromptResult> callback) => Prompt(
            "Geocoding API",
            "Please enter the assigned Google Geocoding API key. You can generate your own using the Google Developer Console (https://console.developers.google.com/apis/credentials)",
            Xameteo.Settings.GoogleKey,
            callback
        );
    }
}