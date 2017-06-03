using System;
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
                Console.WriteLine(data);
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}       