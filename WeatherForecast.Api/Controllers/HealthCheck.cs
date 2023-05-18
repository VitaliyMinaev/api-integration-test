using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Api.Controllers;

[Route("")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult HealthCheck()
    {
        return Ok("Service is online!");
    }
}