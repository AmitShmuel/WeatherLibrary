using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.IsNotNull(data.Location);
            Assert.AreEqual(location.Name.ToLower(), data.Location.Name.ToLower());
            Assert.AreEqual(location.Country.ToLower(), data.Location.Country.ToLower());
            Assert.IsNotNull(data.Sun);
            Assert.AreEqual(data.forecast.Count, 40);
        }
    }
}