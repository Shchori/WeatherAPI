using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi
{
    public interface IWeatherDataService
    {
         WeatherData GetWeatherData(Location location);
    }
}
