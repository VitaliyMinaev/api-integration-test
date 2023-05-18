using FluentResults;
using WeatherForecast.Console.Contracts.Responses;

namespace WeatherForecast.Console.Services;

public interface IWeatherForecastSearchService
{
    public Task<Result<Forecast>> GetForecastAsync(string region);
}