using FluentResults;
using WeatherForecast.Console.Contracts.Responses;
using WeatherForecast.Console.Domain;

namespace WeatherForecast.Console.Services;

public interface IWeatherForecastSearchService
{
    public Task<Result<Forecast>> GetForecastAsync(ForecastSearchRequest request);
}