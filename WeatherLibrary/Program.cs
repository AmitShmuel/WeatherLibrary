using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(
                                                            WeatherDataServiceFactory.WeatherDataKind.OPEN_WEATHER_MAP);
        }
    }
}
