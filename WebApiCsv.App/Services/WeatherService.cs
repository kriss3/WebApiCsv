using WebApiCsv.App.Models;

namespace WebApiCsv.App.Services;

public interface IWeatherService 
{
	IEnumerable<WeatherForecast> GetRandomWeather();
}

public class WeatherService : IWeatherService
{
	private static readonly string[] Summaries =
		[
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		];

	public IEnumerable<WeatherForecast> GetRandomWeather()
    {
		return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})];
	}
}
