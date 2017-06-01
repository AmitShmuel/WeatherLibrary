using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Location(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public override string ToString()
        {
            return Name + ", " + Country;
        }
    }
}
