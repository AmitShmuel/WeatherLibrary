using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Utils;

namespace WeatherLibrary
{
    sealed class OpenWeatherMapService : IWeatherDataService
    {
        private const string key = "ae36efe63a42b75d9696d52d73497acf";

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
            string urlRequest = CreateRequest(location.Name + "," + location.Country);

            try
            {
                XmlDocument response = RequestUtil.WebServiceRequest(urlRequest);
                return ProcessResponse(response);
            }
            catch (Exception)
            {
                throw new WeatherDataServiceException("Request could not be made.");
            }
        }

        private string CreateRequest(string queryString)
        {
            string UrlRequest = "http://api.openweathermap.org/data/2.5/forecast?q=" +
                                 queryString +
                                 "&mode=xml" +
                                 "&appid=" + key;
            return UrlRequest;
        }

        private WeatherData ProcessResponse(XmlDocument locationsResponse)
        {
            WeatherData data = new WeatherData();

            //TODO: parse xml to WeatherData

            return data;
        }

        
    }
}