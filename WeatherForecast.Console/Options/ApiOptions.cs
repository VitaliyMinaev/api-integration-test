namespace WeatherForecast.Console.Options;

public record ApiOptions
{
    public const string Section = "WeatherForecastApi";

    public string Url { get; init; } = String.Empty;
}