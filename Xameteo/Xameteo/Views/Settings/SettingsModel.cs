using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xameteo.Views.Settings
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class SettingsModel : INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        private string _value;

        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        /// <summary>
        /// </summary>
        public Action<SettingsModel> Handler { get; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="handler"></param>
        public SettingsModel(string name, string value, Action<SettingsModel> handler)
        {
            Name = name;
            Value = value;
            Handler = handler;
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}