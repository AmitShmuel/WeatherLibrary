namespace WeatherLibrary
{
    public class TimeSpan
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
