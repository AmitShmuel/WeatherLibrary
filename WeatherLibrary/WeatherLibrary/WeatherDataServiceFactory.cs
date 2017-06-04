namespace WeatherLibrary
{
    /// <summary>
    /// Represents the factory method in charge of
    /// retrieving the IWeatherDataService singeltons kinds.
    /// </summary>
    static class WeatherDataServiceFactory
    {
        /// <summary>
        /// Factory method retrieving different kind of IWeatherDataService singletons.
        /// </summary>
        /// <param name="kind">The kind of IWeatherDataService desired.</param>
        /// <returns>An IWeatherDataService singleton.</returns>
        public static IWeatherDataService GetWeatherDataService(WeatherDataKind kind)
        {
            switch (kind)
            {
                case WeatherDataKind.OPEN_WEATHER_MAP:
                    return OpenWeatherMapService.Instance;
                default:
                    return null;
            }
        }

        public enum WeatherDataKind
        {
            OPEN_WEATHER_MAP
        }
    }
}
