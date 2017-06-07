namespace WeatherLibrary
{
    class Humidity
    {
        public string HumidityValue { get; set; }
        public string HumidityUnit { get; set; }

        public Humidity(string humidityValue, string humidityUnit)
        {
            HumidityValue = humidityValue;
            HumidityUnit = humidityUnit;
        }

        public override string ToString()
        {
            return "Humidity: " + HumidityValue + " " + HumidityUnit;
        }
    }
}
