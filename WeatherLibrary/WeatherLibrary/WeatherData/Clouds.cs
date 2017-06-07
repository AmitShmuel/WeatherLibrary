namespace WeatherLibrary
{
    public class Clouds
    {
        public string CloudsValue { get; set; }
        public string CloudsName { get; set; }

        public Clouds(string cloudsValue, string cloudsName)
        {
            CloudsValue = cloudsValue;
            CloudsName = cloudsName;
        }

        public override string ToString()
        {
            return "Clouds: " + CloudsName;
        }
    }
}
