namespace WeatherLibrary
{
    /// <summary>
    /// Represents a weather data XML DOM from http://openweathermap.org.
    /// </summary>
    public class WeatherData
    {
        public Location Location{ get; set; }
        public TimeSpan TimeSpan { get; set; }
        public Temperature Temperature { get; set; }
        public Humidity Humidity { get; set; }
        public Pressure Pressure { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }

        public override string ToString()
        {
            return TimeSpan + "\n" +
                Location + "\n" +
                Temperature + "\n" +
                Humidity + "\n" +
                Pressure + "\n" +
                Wind + "\n" +
                Clouds + "\n" +
                "--------------------------------------------------------\n";
        }
    }
}