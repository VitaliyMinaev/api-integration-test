using Refit;
using WeatherForecast.Console.Contracts.Responses;

namespace WeatherForecast.Console.Contracts.Api;

public interface IWeatherForecastApi
{
    [Get("/WeatherForecast")]
    public Task<IEnumerable<Forecast>> GetAllAsync();
    [Get("/WeatherForecast/{region}")]
    public Task<Forecast> GetByRegionAsync(string region);
}