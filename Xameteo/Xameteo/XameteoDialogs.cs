using Acr.UserDialogs;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xameteo.Resx;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    internal static class XameteoDialogs
    {
        /// <summary>
        /// </summary>
        public static void HideLoading() => UserDialogs.Instance.HideLoading();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static void ShowLoading() => UserDialogs.Instance.ShowLoading(Resources.Loading_Title, MaskType.Gradient);

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static IDisposable Alert(string title, string message) => UserDialogs.Instance.Alert(message, title);

        /// <summary>
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IDisposable Alert(Exception exception) => UserDialogs.Instance.Alert(exception.Message, exception.GetType().Name);

        /// <summary>
        /// </summary>
        /// <param name="options"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static IDisposable ActionSheet(List<ActionSheetOption> options, string title) => UserDialogs.Instance.ActionSheet(new ActionSheetConfig
        {
            Title = title,
            Options = options,
            UseBottomSheet = false,
            Cancel = new ActionSheetOption(Resources.Button_Cancel)
        });

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Task<bool> PromptYesNo(string title, string message) => UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
        {
            Title = title,
            Message = message,
            OkText = Resources.Global_Yes,
            CancelText = Resources.Global_No
        });

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task<PromptResult> PromptNumber(string title, string message, int value) => UserDialogs.Instance.PromptAsync(new PromptConfig
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
        public static Task<PromptResult> Prompt(string title, string message, string placeholder) => UserDialogs.Instance.PromptAsync(new PromptConfig
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