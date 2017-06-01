using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherLibrary;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(
                                                            WeatherDataServiceFactory.WeatherDataKind.OPEN_WEATHER_MAP);
            try
            {
                WeatherData data = service.GetWeatherData(new Location("Hod Hasharon", "Israel"));
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
