namespace WebApiWeatherBot.Models
{
    public class CityWeather
    {
        public Coord coord { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public string Name { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Sys Sys { get; set; }
        public Rain Rain { get; set; }
       
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
        public double Gust { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
    public class Sys
    {
        public string Country { get; set; }
    }
    public class Rain
    {
        public double h3 { get; set; }
    }
}

