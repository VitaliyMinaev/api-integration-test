using CommandLine;
using WeatherForecast.Console.Output;
using WeatherForecast.Console.Services;

namespace WeatherForecast.Console;

public class WeatherForecastSearchApplication
{
    private readonly IConsoleWriter _consoleWriter;
    private readonly IWeatherForecastSearchService _weatherForecastSearchService;
    public WeatherForecastSearchApplication(IConsoleWriter consoleWriter, IWeatherForecastSearchService weatherForecastSearchService)
    {
        _consoleWriter = consoleWriter;
        _weatherForecastSearchService = weatherForecastSearchService;
    }

    public async Task RunAsync(string[] args)
    {
        await Parser.Default
            .ParseArguments<WeatherForecastSearchAppOptions>(args)
            .WithParsedAsync<WeatherForecastSearchAppOptions>(async (option) =>
            {
                var forecastResult = await _weatherForecastSearchService.GetForecastAsync(option.Region);
                if (forecastResult.IsSuccess)
                {
                    _consoleWriter.WriteLine($"Founded next forecast: {forecastResult.Value}");
                }
                else
                {
                    foreach (var error in forecastResult.Errors)
                    {
                        _consoleWriter.WriteLine($"{error.Reasons.FirstOrDefault()}: {error.Message}");
                    }
                }
            });
    }
}