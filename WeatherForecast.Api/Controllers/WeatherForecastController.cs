using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private static readonly string[] Regions = new[]
    {
        "Vinnytsia Oblast", "Luhansk Oblast", "Zakarpattia Oblast", "Kyiv Oblast", "Mykolaiv Oblast", "Rivne Oblast", "Kharkiv Oblast", "Zhytomyr Oblast", "Chernivtsi Oblast", "Odessa Oblast"
    };


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Enumerable.Range(0, 10).Select(index => new WeatherForecast
        {
            Country = "Ukraine",
            Region = Regions[index],
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }));
    }
    [HttpGet, Route("{region}")]
    public IActionResult Get([FromRoute] string region)
    {
        var regionToFind = Regions.FirstOrDefault(x => x == region);
        if (regionToFind is null)
        {
            return NotFound();
        }
        
        var forecast = new WeatherForecast
        {
            Country = "Ukraine",
            Region = regionToFind,
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
        return Ok(forecast);
    }
}