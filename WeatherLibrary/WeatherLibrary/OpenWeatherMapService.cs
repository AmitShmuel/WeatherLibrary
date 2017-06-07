using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace WeatherLibrary
{
    /// <summary>
    /// Represents a singleton weather service which retrieves different kinds of weather data.
    /// http://openweathermap.org.
    /// </summary>
    sealed class OpenWeatherMapService : IWeatherDataService
    {
        private const string key = "ae36efe63a42b75d9696d52d73497acf";

        private const string forecastRequest = "forecast";

        private const string weatherRequest = "weather";

        private static readonly OpenWeatherMapService instance = new OpenWeatherMapService();

        private OpenWeatherMapService() { }

        /// <summary>
        /// A property to retrieve the singleton instance.
        /// </summary>
        public static OpenWeatherMapService Instance
        {
            get
            {
                return instance;
            }
        }

        public WeatherData GetWeatherData(Location location)
        {
            string urlRequest = CreateUrlRequest(weatherRequest, location.Name);

            Stream response = MakeRequest(urlRequest);

            XDocument xmlDoc = XDocument.Load(response);

            WeatherData data = ProcessWeatherDataXml(xmlDoc);

            return data;
        }

        public List<WeatherData> GetForecast(Location location)
        {
            string urlRequest = CreateUrlRequest(forecastRequest, location.Name + " " + location.Country);

            Stream response = MakeRequest(urlRequest);

            XDocument xmlDoc = XDocument.Load(response);

            List<WeatherData> data = ProcessForecastXml(xmlDoc);

            return data;
        }
        
        private string CreateUrlRequest(string request, string query)
        {
            return "http://api.openweathermap.org/data/2.5/" + request + 
                    "?q=" + query + 
                    "&mode=xml" + 
                    "&appid=" + key;
        }

        private Stream MakeRequest(string urlRequest)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(urlRequest) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                return response.GetResponseStream();
            }
            catch (Exception)
            {
                throw new WeatherDataServiceException("Request could not be made.");
            }
        }

        private WeatherData ProcessWeatherDataXml(XDocument weatherDataXml)
        {
            WeatherData data = new WeatherData();

            data.Location = (from x in weatherDataXml.Descendants("city")
                             select new Location(
                                     x.Attributes("id").First().Value,
                                     x.Attributes("name").First().Value,
                                     x.Descendants("coord").Attributes("lon").First().Value,
                                     x.Descendants("coord").Attributes("lat").First().Value,
                                     x.Descendants("country").First().Value,
                                     new Sun(
                                         x.Descendants("sun").Attributes("rise").First().Value,
                                         x.Descendants("sun").Attributes("set").First().Value)
                                 )).First();

            data.TimeSpan = (from x in weatherDataXml.Descendants("lastupdate")
                             select new TimeSpan(
                                     x.Attributes("value").First().Value,
                                     null
                                 )).First();

            data.Temperature = (from x in weatherDataXml.Descendants("temperature")
                                select new Temperature(
                                        x.Attributes("unit").First().Value,
                                        x.Attributes("value").First().Value,
                                        x.Attributes("min").First().Value,
                                        x.Attributes("max").First().Value
                                    )).First();

            data.Humidity = (from x in weatherDataXml.Descendants("humidity")
                             select new Humidity(
                                     x.Attributes("value").First().Value,
                                     x.Attributes("unit").First().Value
                                 )).First();

            data.Pressure = (from x in weatherDataXml.Descendants("pressure")
                             select new Pressure(
                                     x.Attributes("value").First().Value,
                                     x.Attributes("unit").First().Value
                                 )).First();

            data.Wind = (from x in weatherDataXml.Descendants("wind")
                         select new Wind(
                                    x.Descendants("speed").Attributes("value").First().Value,
                                    x.Descendants("speed").Attributes("name").First().Value,
                                    x.Descendants("direction").Attributes("value").First().Value,
                                    x.Descendants("direction").Attributes("code").First().Value,
                                    x.Descendants("direction").Attributes("name").First().Value
                             )).First();

            data.Clouds = (from x in weatherDataXml.Descendants("clouds")
                           select new Clouds(
                                    x.Attributes("value").First().Value,
                                    x.Attributes("name").First().Value
                               )).First();
            return data;
        }
        
        private List<WeatherData> ProcessForecastXml(XDocument forecastXml)
        {
            List<WeatherData> forecast = new List<WeatherData>();

            var times = from t in forecastXml.Descendants("time") select t;

            foreach (var t in times)
            {
                WeatherData data = new WeatherData();

                data.Location = (from x in forecastXml.Descendants("location")
                                 select new Location
                                 (
                                    null,
                                    x.Descendants("name").First().Value,
                                    x.Descendants("location").Attributes("longitude").First().Value,
                                    x.Descendants("location").Attributes("latitude").First().Value,
                                    x.Descendants("country").First().Value,
                                    null
                                 )).First();

                data.Location.Sun = (from x in forecastXml.Descendants("sun")
                                     select new Sun
                                     (
                                        x.Attributes("rise").First().Value,
                                        x.Attributes("set").First().Value
                                     )).First();

                data.TimeSpan = new TimeSpan(t.FirstAttribute.Value, t.LastAttribute.Value);

                data.Temperature = new Temperature
                    (
                        t.Descendants("temperature").Attributes("unit").First().Value,
                        t.Descendants("temperature").Attributes("value").First().Value,
                        t.Descendants("temperature").Attributes("min").First().Value,
                        t.Descendants("temperature").Attributes("max").First().Value
                    );

                data.Humidity = new Humidity
                    (
                        t.Descendants("humidity").Attributes("value").First().Value,
                        t.Descendants("humidity").Attributes("unit").First().Value
                    );

                data.Pressure = new Pressure
                    (
                        t.Descendants("pressure").Attributes("value").First().Value,
                        t.Descendants("pressure").Attributes("unit").First().Value
                    );

                data.Wind = new Wind
                    (
                        t.Descendants("windSpeed").Attributes("mps").First().Value,
                        t.Descendants("windDirection").Attributes("name").First().Value,
                        t.Descendants("windDirection").Attributes("deg").First().Value,
                        t.Descendants("windDirection").Attributes("code").First().Value,
                        t.Descendants("windSpeed").Attributes("name").First().Value
                    );

                data.Clouds = new Clouds
                    (
                        t.Descendants("clouds").Attributes("all").First().Value,
                        t.Descendants("clouds").Attributes("value").First().Value
                    );

                forecast.Add(data);
            }
            return forecast;
        }
    }
}