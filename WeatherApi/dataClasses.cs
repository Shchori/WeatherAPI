using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
    
    public class Sun
    {
        public DateTime Rise { get; set; }
        public DateTime Set { get; set; }
    }
    
    public class City
    {
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public Sun Sun { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Temperature
    {
        public double Value { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string Unit { get; set; }
    }
    
    public class Humidity
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
    
    public class Pressure
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
    
    public class Speed
    {
        public double Value { get; set; }
        public string Name { get; set; }
    }
    
    public class Direction
    {
        public double Value { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    public class Wind
    {
        public Speed Speed { get; set; }
        public Direction Direction { get; set; }
    }
    
    public class Clouds
    {
        public double Value { get; set; }
        public string Name { get; set; }
    }
    
    public class Precipitation
    {
        public string Mode { get; set; }
    }
    
    public class Weather
    {
        public string Number { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
    }

    public class Lastupdate
    {
        public DateTime Value { get; set; }
    }

    public class WeatherData
    {
        public City City { get; set; }
        public Temperature Temperature { get; set; }
        public Humidity Humidity { get; set; }
        public Pressure Pressure { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Visibility { get; set; }
        public Precipitation Precipitation { get; set; }
        public Weather Weather { get; set; }
        public Lastupdate Lastupdate { get; set; }
    }

}
