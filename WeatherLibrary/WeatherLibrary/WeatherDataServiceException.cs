using System;

namespace WeatherLibrary
{
    /// <summary>
    /// Represents exceptions created from this library.
    /// </summary>
    public class WeatherDataServiceException : Exception
    {
        public WeatherDataServiceException()
        {
        }

        public WeatherDataServiceException(string message)
            : base(message)
        {
        }

        public WeatherDataServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
