using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    static class WeatherDataServiceFactory
    {
        public static IWeatherDataService GetWeatherDataService(WeatherDataKind kind)
        {
            switch (kind)
            {
                case WeatherDataKind.OPEN_WEATHER_MAP:
                    return OpenWeatherMapService.Instance;
                default:
                    return null;
            }
        }

        public enum WeatherDataKind
        {
            OPEN_WEATHER_MAP
        }
    }
}
