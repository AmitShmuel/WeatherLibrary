namespace WeatherLibrary
{
    public class Wind
    {
        public string SpeedValue { get; set; }
        public string SpeedName { get; set; }
        public string DirectionValue { get; set; }
        public string DirectionCode { get; set; }
        public string DirectionName { get; set; }

        public Wind(string speedValue, string speedName, string directionValue, string directionCode, string directionName)
        {
            SpeedValue = speedValue;
            SpeedName = speedName;
            DirectionValue = directionValue;
            DirectionCode = directionCode;
            DirectionName = directionName;
        }

        public override string ToString()
        {
            return "Wind: " + SpeedName + ", " + SpeedValue + " mps";
        }
    }
}
