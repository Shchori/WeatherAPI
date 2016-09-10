using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApi;

namespace TDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetWeatherData()
        {
            WeatherDataServiceFactory obj = WeatherDataServiceFactory.Instance;

            Location location = new Location();
            location.city = "Tel-Aviv";

            IWeatherDataService service = obj.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            WeatherData data = service.GetWeatherData(location);                 //check if get worked
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void Test2GetWeatherData()
        {
            WeatherDataServiceFactory obj = WeatherDataServiceFactory.Instance;

            Location location = new Location();
            location.city = "Barcelona";

           IWeatherDataService service = obj.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            WeatherData data = service.GetWeatherData(location);
            Assert.IsNotNull(data);
        }
    }
}
