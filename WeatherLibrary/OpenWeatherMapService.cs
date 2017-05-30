using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    public sealed class OpenWeatherMapService : IWeatherDataService
    {
        private static readonly OpenWeatherMapService instance = new OpenWeatherMapService();

        private OpenWeatherMapService() { }

        public static OpenWeatherMapService Instance
        {
            get
            {
                return instance;
            }
        }

        public WeatherData GetWeatherData(Location location)
        {
            //TODO: Develop a test for this method and then implement.
            throw new NotImplementedException();
        }
    }
}
