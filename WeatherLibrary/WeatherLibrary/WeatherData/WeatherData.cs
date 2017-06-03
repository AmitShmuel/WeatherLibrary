using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WeatherLibrary
{
    class WeatherData : IEnumerable
    {
        public Location Location { get; set; }
        public Sun Sun { get; set; }
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