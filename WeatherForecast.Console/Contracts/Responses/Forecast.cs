using System.Text.Json.Serialization;

namespace WeatherForecast.Console.Contracts.Responses;

public record Forecast
{
    [JsonPropertyName("country")]
    public string Country { get; init; } = String.Empty;
    [JsonPropertyName("region")]
    public string Region { get; init; } = String.Empty;
    [JsonPropertyName("date")]
    public DateOnly Date { get; init; }
    [JsonPropertyName("temperatureC")]
    public int TemperatureC { get; init; }
    [JsonPropertyName("summary")]
    public string? Summary { get; init; }
}