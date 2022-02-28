using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempRroperty;
        private string windRoute;
        private int windSpeed;
        private enum Precipitation
        {
            sunny,
            cloudy,
            rain,
            snow
        }
        public string WindRoute { get;set; }
        public int WindSpeed { get;set;}
        public WeatherControl(string windRoute, int windSpeed)
        {
            this.windRoute = windRoute;
            this.windSpeed = windSpeed;
        }
        public int Temp
        {
            get => (int)GetValue(TempRroperty);
            set => SetValue(TempRroperty,value);
        }
        static WeatherControl()
        {
            TempRroperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int t = (int) value;
            if (t >= 50 && t >= -50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= 50 && t >= -50)
                return t;
            else
                return 0;

        }
    }
}
