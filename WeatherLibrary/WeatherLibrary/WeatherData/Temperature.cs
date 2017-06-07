namespace WeatherLibrary
{
    class Temperature
    {
        public string TemperatureUnit { get; set; }
        public string TemperatureValue { get; set; }
        public string TemperatureMinValue { get; set; }
        public string TemperatureMaxValue { get; set; }

        public Temperature(string temperatureUnit, string temperatureValue, string temperatureMinValue, string temperatureMaxValue)
        {
            TemperatureUnit = temperatureUnit;
            TemperatureValue = temperatureValue;
            TemperatureMinValue = temperatureMinValue;
            TemperatureMaxValue = temperatureMaxValue;
        }

        public override string ToString()
        {
            return "Temperature: " + TemperatureValue + " " + TemperatureUnit +
                   ", Min: " + TemperatureMinValue + ", Max: " + TemperatureMaxValue;
        }
    }
}
