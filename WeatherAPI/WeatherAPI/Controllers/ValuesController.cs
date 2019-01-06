using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/GetWeatherInformation
        [HttpGet]
        public async Task<Weather> GetWeather(string zipcode)
        {
            if (String.IsNullOrEmpty(zipcode) && !zipcode.All(char.IsDigit))
                return null;

            Weather weather = new Weather();

            #region Temperature and City
            String URL = String.Format(Constants.RestURL.CityURL, zipcode);

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jObj = JObject.Parse(content);

                //Extract Information from API
                weather.CityName = JObject.Parse(jObj["location"].ToString()).SelectToken("region").ToString().Trim();
                weather.Temprature = Convert.ToDecimal(JObject.Parse(jObj["current"].ToString()).SelectToken("temp_c").ToString()).ToString("0") + "°";
                weather.Longtitude = JObject.Parse(jObj["location"].ToString()).SelectToken("lon").ToString().Trim();
                weather.Latitude = JObject.Parse(jObj["location"].ToString()).SelectToken("lat").ToString().Trim();
            }
            #endregion

            #region TimeZone
            URL = String.Format(Constants.RestURL.TimeZoneURL, weather.Latitude, weather.Longtitude);

            httpClient = new HttpClient();
            response = await httpClient.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jObj = JObject.Parse(content);

                //Extract Information from API
                weather.TimeZone = jObj.SelectToken("timeZoneName").ToString().Trim();
            }
            #endregion

            #region Elevation
            URL = String.Format(Constants.RestURL.ElevationURL, weather.Latitude, weather.Longtitude);

            httpClient = new HttpClient();
            response = await httpClient.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jObj = JObject.Parse(content);

                //Extract Information from API
                weather.Elevation = Convert.ToDouble(jObj.SelectToken("results[0].elevation").ToString()).ToString("0.00");
            }
            #endregion

            return weather;
        }
    }
}
