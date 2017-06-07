namespace WeatherLibrary
{
    /// <summary>
    /// Represents the location of the weather data.
    /// </summary>
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Country { get; set; }
        public Sun Sun { get; set; }

        public Location(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public Location(string id, string name, string longitude, string latitude, string country, Sun sun)
        {
            Id = id;
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
            Country = country;
            Sun = sun;
        }

        public override string ToString()
        {
            return Name + ", " + Country +
                ":\nLatitude: " + Latitude + ", Longitude: " + Longitude +
                "\n" + Sun.ToString();
        }
    }
}
