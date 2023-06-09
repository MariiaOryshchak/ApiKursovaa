using Microsoft.AspNetCore.Mvc;
using WebApiWeatherBot.Clients;
using WebApiWeatherBot.ControllersBase;
using WebApiWeatherBot.Models;

namespace WebApiWeatherBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticController : Controller
    {
        private readonly ILogger<StatisticController> _logger;
        public StatisticController(ILogger<StatisticController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Statistic")]
        public List<CityMain> CityGet()
        {
            DataBase dataBase = new DataBase();
            return dataBase.SelectStatistic().Result;
        }

    }
}
