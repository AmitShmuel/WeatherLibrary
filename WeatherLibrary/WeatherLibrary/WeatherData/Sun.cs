namespace WeatherLibrary
{
    /// <summary>
    /// Represents info regarding sunset and sunrise.
    /// </summary>
    class Sun
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        public Sun(string sunrise, string sunset)
        {
            Sunrise = sunrise;
            Sunset = sunset;
        }

        public override string ToString()
        {
            return "Sun rise: " + Sunrise + ", Sun set: " + Sunset;
        }
    }
}
