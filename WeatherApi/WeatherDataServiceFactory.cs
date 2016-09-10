using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherApi
{
    public class WeatherDataServiceFactory
    {

        public const string OPEN_WEATHER_MAP = "OPEN_WEATHER_MAP";

        private static WeatherDataServiceFactory instance;

        private WeatherDataServiceFactory() { }

        public static WeatherDataServiceFactory Instance
        {
            get
            {
                if (instance == null)                                   //return new instance if not created yet
                {
                    instance = new WeatherDataServiceFactory();
                }

                return instance;
            }
        }

        public IWeatherDataService GetWeatherDataService(string s)
        {
            IWeatherDataService service = null;
            if (s == OPEN_WEATHER_MAP)
            {
                service = openWeatherDataService.Instance;
            }
            return service;
        }

    }
}


