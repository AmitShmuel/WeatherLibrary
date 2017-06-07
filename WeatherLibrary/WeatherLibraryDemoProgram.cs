using System;
using System.Collections.Generic;
using WeatherLibrary;

namespace MainProgram
{
    /// <summary>
    /// Demo Class using the WeatherLibrary library.
    /// </summary>
    class WeatherLibraryDemoProgram
    {
        static void Main(string[] args)
        {
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(
                                                            WeatherDataServiceFactory.WeatherDataKind.OPEN_WEATHER_MAP);
            try
            {
                WeatherData weatherData = service.GetWeatherData(new Location("Hod Hasharon", "IL"));

                Console.WriteLine(weatherData);

                List<WeatherData> forecast = service.GetForecast(new Location("Hod Hasharon", "IL"));

                foreach (var t in forecast)
                {
                    Console.WriteLine(t);
                }
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}       