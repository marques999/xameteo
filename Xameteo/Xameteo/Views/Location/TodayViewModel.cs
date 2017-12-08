using System.ComponentModel;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TodayViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        private string _text;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        public string Text
        {
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
            get => _text;
        }

        /// <summary>
        /// </summary>
        public TodayViewModel()
        {
            _text = "Ola Kira!";
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}