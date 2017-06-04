namespace WeatherLibrary
{
    /// <summary>
    /// Represents a forecast of specific date and time.
    /// </summary>
    class Time
    {
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string SymbolNumber { get; set; }
        public string SymbolName { get; set; }
        public string SymbolVar { get; set; }
        public string WindDirectionDegree { get; set; }
        public string WindDirectionCode { get; set; }
        public string WindDirectionName { get; set; }
        public string WindSpeedMps { get; set; }
        public string WindSpeedName { get; set; }
        public string TemperatureUnit { get; set; }
        public string TemperatureValue { get; set; }
        public string TemperatureMinValue { get; set; }
        public string TemperatureMaxValue { get; set; }
        public string PressureUnit { get; set; }
        public string PressureValue { get; set; }
        public string HumidityValue { get; set; }
        public string HumidityUnit { get; set; }
        public string CloudsValue { get; set; }
        public string CloudsAll { get; set; }
        public string CloudsUnit { get; set; }

        public Time(string fromTime, string toTime, string symbolNumber, string symbolName, string symbolVar, string windDirectionDegree, string windDirectionCode, string windDirectionName, string windSpeedMps, string windSpeedName, string temperatureUnit, string temperatureValue, string temperatureMinValue, string temperatureMaxValue, string pressureUnit, string pressureValue, string humidityValue, string humidityUnit, string cloudsValue, string cloudsAll, string cloudsUnit)
        {
            FromTime = fromTime;
            ToTime = toTime;
            SymbolNumber = symbolNumber;
            SymbolName = symbolName;
            SymbolVar = symbolVar;
            WindDirectionDegree = windDirectionDegree;
            WindDirectionCode = windDirectionCode;
            WindDirectionName = windDirectionName;
            WindSpeedMps = windSpeedMps;
            WindSpeedName = windSpeedName;
            TemperatureUnit = temperatureUnit;
            TemperatureValue = temperatureValue;
            TemperatureMinValue = temperatureMinValue;
            TemperatureMaxValue = temperatureMaxValue;
            PressureUnit = pressureUnit;
            PressureValue = pressureValue;
            HumidityValue = humidityValue;
            HumidityUnit = humidityUnit;
            CloudsValue = cloudsValue;
            CloudsAll = cloudsAll;
            CloudsUnit = cloudsUnit;
        }

        public override string ToString()
        {
            return "From " + FromTime + " To " + ToTime +
                   "\n" + SymbolName +
                   "\nWind direction: " + WindDirectionDegree + " degrees, " + WindDirectionName +
                   "\nWind speed: " + WindSpeedMps + " mps" +
                   "\nTemperature: " + TemperatureValue + " " + TemperatureUnit +
                   ", Min: " + TemperatureMinValue + ", Max: " + TemperatureMaxValue +
                   "\nPressure: " + PressureValue + " " + PressureUnit +
                   "\nHumidity: " + HumidityValue + " " + HumidityUnit +
                   "\nClouds: " + CloudsValue;
        }
    }
}