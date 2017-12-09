using System;
using System.Globalization;

using Xamarin.Forms;
using Xameteo.Units;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class AbstractUnitConverter<T> : IValueConverter where T : Unit
    {
        /// <summary>
        /// </summary>
        private readonly Unit _instance;

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        protected AbstractUnitConverter(T instance)
        {
            _instance = instance;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string Prefix(string value, object parameter)
        {
            return parameter is string prefix ? prefix + value : value;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double temperature ? Prefix(_instance.Convert(temperature), parameter) : "N/A";
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class DistanceConverter : AbstractUnitConverter<Distance>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DistanceConverter() : base(Xameteo.Settings.Distance)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PrecipitationConverter : AbstractUnitConverter<Precipitation>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PrecipitationConverter() : base(Xameteo.Settings.Precipitation)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PressureConverter : AbstractUnitConverter<Pressure>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public PressureConverter() : base(Xameteo.Settings.Pressure)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TemperatureConverter : AbstractUnitConverter<Temperature>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public TemperatureConverter() : base(Xameteo.Settings.Temperature)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class VelocityConverter : AbstractUnitConverter<Velocity>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public VelocityConverter() : base(Xameteo.Settings.Velocity)
        {
        }
    }
}