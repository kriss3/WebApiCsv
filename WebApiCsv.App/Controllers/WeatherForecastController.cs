using Microsoft.AspNetCore.Mvc;
using WebApiCsv.App.Models;
using WebApiCsv.App.Services;

namespace WebApiCsv.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IWeatherService weatherService) : ControllerBase
    {
        private readonly IWeatherService weatherService = weatherService;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherService.GetRandomWeather();
        }
    }
}
