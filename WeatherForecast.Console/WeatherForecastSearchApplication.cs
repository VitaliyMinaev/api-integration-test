using System.Text.Json;
using WeatherForecast.Console.Contracts.Api;

namespace WeatherForecast.Console;

public class WeatherForecastSearchApplication
{
    private readonly IWeatherForecastApi _api;
    public WeatherForecastSearchApplication(IWeatherForecastApi api)
    {
        _api = api;
    }

    public async Task RunAsync(string[] args)
    {
        var forecasts = await _api.GetAllAsync();

        var json = JsonSerializer.Serialize(forecasts, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        
        System.Console.WriteLine(json);
    }
}