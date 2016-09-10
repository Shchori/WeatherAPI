using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataServiceFactory obj = WeatherDataServiceFactory.Instance;                     //get instance of weather data service factory

            Location location = new Location();                                                     //create location object
            location.city = "london";
            try
            {
                IWeatherDataService service = obj.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
                WeatherData data = service.GetWeatherData(location);
                System.Console.WriteLine("\n city :" + data.City.Name+"\n temp: "+data.Temperature.Value.ToString()+"\n clouds mode :"+data.Clouds.Name);
                System.Console.Read();
            }
            catch (Exception e) {
                System.Console.WriteLine(e.ToString());
            }

           }
    }
}
