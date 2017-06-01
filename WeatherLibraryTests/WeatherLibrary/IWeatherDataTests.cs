using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Location location = new Location("Hod Hasharon", "Israel");

            WeatherData data = null;
            try
            {
                data = service.GetWeatherData(location);
            }
            catch (WeatherDataServiceException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(location.Name, data.Location.Name);
            Assert.AreEqual(location.Country, data.Location.Country);

            // can maybe use Assert.AreEqual(location, data.Location);
        }
    }
}