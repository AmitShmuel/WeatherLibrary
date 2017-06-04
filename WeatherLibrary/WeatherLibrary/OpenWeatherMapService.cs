using System;
using System.Linq;
using System.Xml.Linq;
using Utils;

namespace WeatherLibrary
{
    /// <summary>
    /// Represents a singleton weather service which retrieves different kinds of weather data.
    /// http://openweathermap.org.
    /// </summary>
    sealed class OpenWeatherMapService : IWeatherDataService
    {
        private const string key = "ae36efe63a42b75d9696d52d73497acf";

        private const string weatherDataRequest = "http://api.openweathermap.org/data/2.5/forecast?q=";

        // private const string addRequestsAsYouLike = "";

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
            string urlRequest = CreateRequest(weatherDataRequest, location.Name + "," + location.Country);

            try
            {
                XDocument response = RequestUtil.XmlWebServiceRequest(urlRequest);
                return ProcessResponse(response);
            }
            catch (Exception)
            {
                throw new WeatherDataServiceException("Request could not be made.");
            }
        }

        /// <summary>
        /// Creates a string representing the url request sent to the service.
        /// </summary>
        /// <param name="request">The initial url request.</param>
        /// <param name="query">The query for the request.</param>
        /// <returns>A string representing the url request.</returns>
        private string CreateRequest(string request, string query)
        {
            return request + query + "&mode=xml" + "&appid=" + key;
        }

        /// <summary>
        /// Proccesses the XML response and creating a WeatherData object out of it.
        /// </summary>
        /// <param name="weatherDataResponse">The XML document to be proccessed.</param>
        /// <returns>WeatherData object containing the data from the XML.</returns>
        private WeatherData ProcessResponse(XDocument weatherDataResponse)
        {
            WeatherData data = new WeatherData();

            data.Location = (from x in weatherDataResponse.Descendants("location")
                             let locationDescendant = x.Descendants("location").Attributes()
                             select new Location(
                                     x.Descendants("name").First().Value,
                                     x.Descendants("country").First().Value,
                                     locationDescendant.ElementAt(0).Value,
                                     locationDescendant.ElementAt(1).Value,
                                     locationDescendant.ElementAt(2).Value,
                                     locationDescendant.ElementAt(3).Value,
                                     locationDescendant.ElementAt(4).Value
                                 )).First();

            data.Sun = (from x in weatherDataResponse.Descendants("sun")
                        select new Sun(
                                x.Attributes().First().Value,
                                x.Attributes().Last().Value
                            )).First();

            var times = from x in weatherDataResponse.Descendants("time") select x;

            foreach (var x in times)
            {
                data.forecast.Add
                (
                    new Time
                    (
                        x.FirstAttribute.Value, x.LastAttribute.Value, 
                        x.Descendants("symbol").Attributes("number").First().Value,
                        x.Descendants("symbol").Attributes("name").First().Value, 
                        x.Descendants("symbol").Attributes("var").First().Value,
                        x.Descendants("windDirection").Attributes("deg").First().Value,
                        x.Descendants("windDirection").Attributes("code").First().Value,
                        x.Descendants("windDirection").Attributes("name").First().Value,
                        x.Descendants("windSpeed").Attributes("mps").First().Value,
                        x.Descendants("windSpeed").Attributes("name").First().Value,
                        x.Descendants("temperature").Attributes("unit").First().Value,
                        x.Descendants("temperature").Attributes("value").First().Value,
                        x.Descendants("temperature").Attributes("min").First().Value,
                        x.Descendants("temperature").Attributes("max").First().Value,
                        x.Descendants("pressure").Attributes("unit").First().Value,
                        x.Descendants("pressure").Attributes("value").First().Value,
                        x.Descendants("humidity").Attributes("value").First().Value,
                        x.Descendants("humidity").Attributes("unit").First().Value,
                        x.Descendants("clouds").Attributes("value").First().Value,
                        x.Descendants("clouds").Attributes("all").First().Value,
                        x.Descendants("clouds").Attributes("unit").First().Value
                    )
                );
            }

            return data;
        }
    }
}