using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController] //optional behaviour= parameter, attriibute routing + error handling
[Route("[controller]")] //routing pattern [controller'sNamewithout"controller"]
public class WeatherForecastController : ControllerBase //Base class Get()
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] //GET operation app.get
    public IEnumerable<WeatherForecast> Get() //Return result
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
