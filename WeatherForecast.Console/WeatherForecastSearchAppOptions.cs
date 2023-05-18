using CommandLine;

namespace WeatherForecast.Console;

public class WeatherForecastSearchAppOptions
{
    [Option('r', "region", Required = true, HelpText = "Please specify the region")]
    public string Region { get; set; } = String.Empty;
}

