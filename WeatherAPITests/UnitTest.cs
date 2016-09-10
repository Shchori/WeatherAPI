using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace WeatherAPITests
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

            CityWeather tmp = obj.GetWeatherDataService(location);                  //check if get worked
            Assert.IsNotNull(tmp);
        }

        [TestMethod]
        public void Test2GetWeatherData()
        {
            WeatherDataServiceFactory obj = WeatherDataServiceFactory.Instance;

            Location location = new Location();
            location.city = "Barcelona";

            CityWeather tmp = obj.GetWeatherDataService(location);                  //check if get worked
            Assert.IsNotNull(tmp);
        }
    }
}

}
