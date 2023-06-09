using Microsoft.AspNetCore.Mvc;
using WebApiWeatherBot.Clients;
using WebApiWeatherBot;
using WebApiWeatherBot.Models;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApiWeatherBot.ControllersBase
{
    [ApiController]
    [Route("[controller]")]
    public class CityWeatherController : Controller
    {
       private readonly ILogger<CityWeatherController> _logger;
        public CityWeatherController(ILogger<CityWeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "CityWeatherGet")]
        public async Task<CityWeather> City(string query)
        {
            DataBase dataBase = new DataBase();
            WeatherClient client = new WeatherClient();
            var cityWeather = await client.GetCityWeatherAsync(query);
            await dataBase.InsertCityWeatherAsync(cityWeather, query);
            return cityWeather;
        }

        [HttpPost(Name = "CityWeather")]
        public async Task<CityWeather> City2(string CityName)
        {
            DataBase dataBase = new DataBase();
            WeatherClient client = new WeatherClient();
            var cityWeather = await client.GetCityWeatherAsync(CityName);
            await dataBase.InsertCityWeatherAsync(cityWeather, CityName);
            return cityWeather;
        }
        [HttpPut( Name = "UpdateCityWeather")]
        public async Task<CityWeather> UpdateCityWeather(string CityName)
        {

            DataBase dataBase = new DataBase();
            WeatherClient client = new WeatherClient();
            var cityWeather = await client.GetCityWeatherAsync(CityName);
            await dataBase.UpdateCityWeather( cityWeather, CityName);
            return cityWeather;
        }
        [HttpDelete(Name = "DeleteAllWeather")]
        public async Task<CityWeather> DeleteAllCityWeatherAsync(string CityName)
        {
            DataBase dataBase = new DataBase();
            WeatherClient client = new WeatherClient();
            var cityWeather = await client.GetCityWeatherAsync(CityName);
            await dataBase.DeleteAllCityWeatherAsync(CityName);
            return cityWeather;
        }      
            
    }
}
