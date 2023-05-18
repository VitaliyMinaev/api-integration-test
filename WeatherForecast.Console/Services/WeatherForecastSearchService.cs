using FluentResults;
using Refit;
using WeatherForecast.Console.Contracts.Api;
using WeatherForecast.Console.Contracts.Responses;

namespace WeatherForecast.Console.Services;

public class WeatherForecastSearchService : IWeatherForecastSearchService
{
    private readonly IWeatherForecastApi _api;
    
    public WeatherForecastSearchService(IWeatherForecastApi api)
    {
        _api = api;
    }

    public async Task<Result<Forecast>> GetForecastAsync(string region)
    {
        try
        {
            var weatherForecast = await _api.GetByRegionAsync(region);
            return Result.Ok(weatherForecast);
        }
        catch (ValidationApiException e)
        {
            return Result.Fail(new Error(e.Message, new Error(nameof(ValidationApiException))));
        }
        catch (Exception e)
        {
            throw;
        }
    }
}