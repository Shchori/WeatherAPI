using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherApi
{

    class openWeatherDataService : IWeatherDataService
    {
        private static openWeatherDataService instance;  //singeltone

        private openWeatherDataService() { }

        public static openWeatherDataService Instance
        {
            get
            {
                if (instance == null)                                   //return new instance if not created yet
                {
                    instance = new openWeatherDataService();
                }

                return instance;
            }
        }

        WeatherData IWeatherDataService.GetWeatherData(Location location)
        {
            WebClient client = new WebClient();

            client.Encoding = System.Text.Encoding.UTF8;

            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + location.city + "&mode=xml&appid=214ef4d7eb0abb9ccb9b45bae0edee0e";        //url with location & app id
            WeatherData data;
            string xml;

            try
            {
                xml = client.DownloadString(url);                                          //download xml according to url
                XDocument doc = XDocument.Parse(xml);
                data = (from c in doc.Descendants("current")                        //parseXML
                                    select new WeatherData
                                    {
                                        City = (from city in c.Descendants("city")
                                                select new City
                                                {
                                                    Id = (string)city.Attribute("id"),
                                                    Name = (string)city.Attribute("name"),
                                                    Country = (string)city.Attribute("country"),
                                                    Coord = (from coord in city.Descendants("coord")
                                                             select new Coord
                                                             {
                                                                 Lon = (double)coord.Attribute("lon"),
                                                                 Lat = (double)coord.Attribute("lat")
                                                             }).First(),
                                                    Sun = (from sun in city.Descendants("sun")
                                                           select new Sun
                                                           {
                                                               Set = Convert.ToDateTime((string)sun.Attribute("set")),
                                                               Rise = Convert.ToDateTime((string)sun.Attribute("rise")),


                                                           }).First()
                                                }).First(),
                                        Temperature = (from temp in c.Descendants("temperature")
                                                       select new Temperature
                                                       {
                                                           Value = (double)temp.Attribute("value"),
                                                           Min = (double)temp.Attribute("min"),
                                                           Max = (double)temp.Attribute("max"),
                                                           Unit = (string)temp.Attribute("unit")
                                                       }).First(),
                                        Pressure = (from pressure in c.Descendants("pressure")
                                                    select new Pressure
                                                    {
                                                        Value = (double)pressure.Attribute("value"),
                                                        Unit = (string)pressure.Attribute("unit")
                                                    }).First(),
                                        Wind = (from wind in c.Descendants("wind")
                                                select new Wind
                                                {
                                                    Speed = (from speed in wind.Descendants("speed")
                                                             select new Speed
                                                             {
                                                                 Value = (double)speed.Attribute("value"),
                                                                 Name = (string)speed.Attribute("name")
                                                             }).First(),
                                                    Direction = (from direction in wind.Descendants("direction")
                                                                 select new Direction
                                                                 {
                                                                     Value = (double)direction.Attribute("value"),
                                                                     Code = (string)direction.Attribute("code"),
                                                                     Name = (string)direction.Attribute("name")
                                                                 }).First()
                                                }).First(),
                                        Clouds = (from clouds in c.Descendants("clouds")
                                                  select new Clouds
                                                  {
                                                      Value = (double)clouds.Attribute("value"),
                                                      Name = (string)clouds.Attribute("name")
                                                  }).First(),
                                        Precipitation = (from precipitation in c.Descendants("precipitation")
                                                         select new Precipitation
                                                         {
                                                             Mode = (string)precipitation.Attribute("mode")
                                                         }).First(),
                                        Weather = (from weather in c.Descendants("weather")
                                                   select new Weather
                                                   {
                                                       Icon = (string)weather.Attribute("icon"),
                                                       Number = (string)weather.Attribute("number"),
                                                       Value = (string)weather.Attribute("value")
                                                   }).First(),
                                        Lastupdate = (from update in c.Descendants("lastupdate")
                                                      select new Lastupdate
                                                      {
                                                          Value = Convert.ToDateTime((string)update.Attribute("value"))
                                                      }).First()
                                    }).First();
            }
            catch (WebException ex)
            {

                throw new WeatherDataServiceException(ex + "Internet Connection failed.");

            }
            catch (Exception e) {
                throw new WeatherDataServiceException(e + "can not parse XML response.");
            }

           
            return data;
        }
    }
}
