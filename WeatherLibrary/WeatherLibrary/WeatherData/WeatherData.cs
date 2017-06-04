using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WeatherLibrary
{
    /// <summary>
    /// Represents a weather data XML DOM from http://openweathermap.org.
    /// </summary>
    class WeatherData : IEnumerable
    {
        /// <summary>
        /// Location the data refers to.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Sun set and sun rise times.
        /// </summary>
        public Sun Sun { get; set; }

        /// <summary>
        /// A 5 day / 3 hour weather forecast
        /// </summary>
        public List<Time> forecast = new List<Time>();

        public IEnumerator GetEnumerator()
        {
            return forecast.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Location.ToString()).AppendLine()
              .Append(Sun.ToString()).AppendLine();

            foreach (Time t in forecast)
            {
                sb.Append(t.ToString()).AppendLine();
            }

            return sb.ToString();
        }
    }
}