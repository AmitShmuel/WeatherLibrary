namespace WeatherLibrary
{
    class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Altitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Geobase { get; set; }
        public string Geobaseid { get; set; }

        public Location(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public Location(string name, string country, string altitude, string latitude, string longitude, string geobase, string geobaseid) 
            : this(name, country)
        {
            Altitude = altitude;
            Latitude = latitude;
            Geobase = geobase;
            Geobaseid = geobaseid;
        }

        public override string ToString()
        {
            return Name + ", " + Country +
                ":\nAltitude: " + Altitude + ", Latitude: " + Latitude + ", Longitude: " + Longitude +
                ", Geobase: " + Geobase + ", Geobase ID: " + Geobaseid;
        }
    }
}
