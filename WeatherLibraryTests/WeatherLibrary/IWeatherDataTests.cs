using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WeatherLibrary.Tests
{
    [TestClass()]
    public class IWeatherDataServiceTests
    {
        [TestMethod()]
        public void GetWeatherDataTest()
        {
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(
                                                            WeatherDataServiceFactory.WeatherDataKind.OPEN_WEATHER_MAP);

            Location location = new Location("Hod Hasharon", "IL");

            WeatherData data = null;
            try
            {
                data = service.GetWeatherData(location);
            }
            catch (WeatherDataServiceException)
            {
                Assert.Fail();
            }

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Location);
            Assert.IsNotNull(data.Clouds);
            Assert.IsNotNull(data.Humidity);
            Assert.IsNotNull(data.Pressure);
            Assert.IsNotNull(data.Temperature);
            Assert.IsNotNull(data.Wind);
            Assert.IsNotNull(data.TimeSpan);
        }

        [TestMethod]
        public void GetForecastTest()
        {
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(
                                                            WeatherDataServiceFactory.WeatherDataKind.OPEN_WEATHER_MAP);

            Location location = new Location("Hod Hasharon", "IL");

            List<WeatherData> forecast = null;

            try
            {
                forecast = service.GetForecast(location);
            }
            catch (WeatherDataServiceException)
            {
                Assert.Fail();
            }

            Assert.IsTrue(forecast.Count > 10);
        }
    }
}