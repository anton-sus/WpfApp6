using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }
    class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        private string wind_direction;
        private int wind_speed;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public WeatherControl(string wind, int windsp, Precipitation precipitation)
        {
            this.WindDirection = wind;
            this.WindSpeed = windsp;
            this.precipitation = precipitation;
        }

        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }


        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50)
                return v;
            else
                return 0;
        }
    }
}
