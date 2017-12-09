using System;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        /// <param name="ex"></param>
        /// <returns></returns>
        public Task Alert(Exception ex) => _userDialogs.AlertAsync(ex.Message, ex.GetType().Name);

        /// <summary>
        /// </summary>
        private readonly ActionSheetOption _cancelButton = new ActionSheetOption(Resources.Button_Cancel);

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool ValidatePrompt(PromptResult result) => result.Ok && result.Text.Trim().Length > 0;

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
        /// <param name="options"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public IDisposable ActionSheet(List<ActionSheetOption> options, string title) => _userDialogs.ActionSheet(new ActionSheetConfig
        {
            Title = title,
            Options = options,
            Cancel = _cancelButton,
            UseBottomSheet = false
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

        public Task<PromptResult> PromptNumber(string title, string message, int value) => _userDialogs.PromptAsync(new PromptConfig
        {
            Title = title,
            Message = message,
            IsCancellable = true,
            Text = value.ToString("D"),
            InputType = InputType.Number,
            OkText = Resources.Button_OK,
            CancelText = Resources.Button_Cancel
        });

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="placeholder"></param>
        public Task<PromptResult> Prompt(string title, string message, string placeholder) => _userDialogs.PromptAsync(new PromptConfig
        {
            Title = title,
            Message = message,
            Text = placeholder,
            IsCancellable = true,
            OkText = Resources.Button_OK,
            InputType = InputType.Default,
            CancelText = Resources.Button_Cancel
        });
    }
}