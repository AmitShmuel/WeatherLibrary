namespace WeatherLibrary
{
    /// <summary>
    /// Represents a time span of a forecast.
    /// </summary>
    class TimeSpan
    {
        public string FromTime { get; set; }
        public string ToTime { get; set; }

        public TimeSpan(string fromTime, string toTime)
        {
            FromTime = fromTime;
            ToTime = toTime;
        }

        public override string ToString()
        {
            return "From " + FromTime + (ToTime == null ? "" : " To " + ToTime);
        }
    }
}
