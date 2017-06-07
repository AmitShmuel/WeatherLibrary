using System.Collections.Generic;

namespace WeatherLibrary
{
    /// <summary>
    /// An interface represents a weather service in which all services must implement.
    /// Includes different methods retrieving weather data.
    /// </summary>
    interface IWeatherDataService
    {
        /// <summary>
        /// Retrieves a WeatherData object filled with the data given from the service.
        /// </summary>
        /// <param name="location">The location in which the data will be refering to.</param>
        /// <returns>WeatherData object containing the weather data.</returns>
        WeatherData GetWeatherData(Location location);

        /// <summary>
        /// Retrieves a forecast of 5 days / 3 hours, sum of 40 WeatherData objects in a list. 
        /// </summary>
        /// <param name="location">The location in which the data will be refering to.</param>
        /// <returns>List of 40 WeatherData objects</returns>
        List<WeatherData> GetForecast(Location location);
    }
}
