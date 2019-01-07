using WeatherAPI.Controllers;
using Xunit;
using Xunit.Abstractions;

namespace WeatherAppUnitTest
{
    public class UnitTest1
    {
        private readonly ValuesController _weatherapi;

        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1()
        {
            _weatherapi = new ValuesController();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ZipCodeIsNull(string value)
        {
            var result = _weatherapi.GetWeather(value).Result;

            if (result == null)
                Assert.False(true, "zipcode should not be empty");
        }

        [Theory]
        [InlineData("string")]
        public void ZipCodeIsNotInt(string value)
        {
            var result = _weatherapi.GetWeather(value).Result;

            if (result == null)
                Assert.False(true, "zipcode should be numeric.");
        }

        [Theory]
        [InlineData("10001")]
        [InlineData("122")]
        public void ZipCodeIsValid(string value)
        {
            var result = _weatherapi.GetWeather(value).Result;

            if (result != null)
                Assert.True(true, "zipcode code is valid. City Name:" + result.CityName);
            else
                Assert.False(true, "invalid zip code.");
        }
    }
}
