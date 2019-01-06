using System;
namespace WeatherAPI.Constants
{
    public static class RestURL
    {
        public static string CityURL = "http://api.apixu.com/v1/current.json?key=bfc0f27082ee476988d104632181810&q={0}";
        public static string TimeZoneURL = "https://maps.googleapis.com/maps/api/timezone/json?location={0},{1}&timestamp=1331161200&key=AIzaSyA-P3Udc7bDrhoLNs61o2UBCKk-MEfwopM";
        public static string ElevationURL = "https://maps.googleapis.com/maps/api/elevation/json?locations={0},{1}&key=AIzaSyA-P3Udc7bDrhoLNs61o2UBCKk-MEfwopM";
    }
}