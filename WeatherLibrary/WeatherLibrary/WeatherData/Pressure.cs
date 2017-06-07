namespace WeatherLibrary
{
    public class Pressure
    {
        public string PressureValue { get; set; }
        public string PressureUnit { get; set; }

        public Pressure(string pressureValue, string pressureUnit)
        {
            PressureValue = pressureValue;
            PressureUnit = pressureUnit;
        }

        public override string ToString()
        {
            return "Pressure: " + PressureValue + " " + PressureUnit;
        }
    }
}
