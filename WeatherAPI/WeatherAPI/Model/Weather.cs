namespace WeatherAPI.Model
{
    public class Weather
    {
        public string CityName { get; set; } = string.Empty;
        public string Temprature { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public string Elevation { get; set; } = string.Empty;
        public string Longtitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
    }
}