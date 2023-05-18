using CommandLine;
using WeatherForecast.Console.Contracts.Api;
using WeatherForecast.Console.Output;

namespace WeatherForecast.Console;

public class WeatherForecastSearchApplication
{
    private readonly IWeatherForecastApi _api;
    private readonly IConsoleWriter _consoleWriter;
    public WeatherForecastSearchApplication(IWeatherForecastApi api, IConsoleWriter consoleWriter)
    {
        _api = api;
        _consoleWriter = consoleWriter;
    }

    public async Task RunAsync(string[] args)
    {
        await Parser.Default
            .ParseArguments<WeatherForecastSearchAppOptions>(args)
            .WithParsedAsync<WeatherForecastSearchAppOptions>((option) =>
            {
                _consoleWriter.WriteLine($"The region was: {option.Region}");
                return Task.CompletedTask;
            });
    }
}