using FluentResults;
using FluentValidation;
using Refit;
using WeatherForecast.Console.Contracts.Api;
using WeatherForecast.Console.Contracts.Responses;
using WeatherForecast.Console.Domain;

namespace WeatherForecast.Console.Services;

public class WeatherForecastSearchService : IWeatherForecastSearchService
{
    private readonly IWeatherForecastApi _api;
    private readonly IValidator<ForecastSearchRequest> _validator;

    public WeatherForecastSearchService(IWeatherForecastApi api, IValidator<ForecastSearchRequest> validator)
    {
        _api = api;
        _validator = validator;
    }

    public async Task<Result<Forecast>> GetForecastAsync(ForecastSearchRequest request)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult.Errors.Select(x => new Error(x.ErrorMessage)));
            }
            
            var weatherForecast = await _api.GetByRegionAsync(request.Region);
            return Result.Ok(weatherForecast);
        }
        catch (ValidationApiException e)
        {
            return Result.Fail(new Error(e.Message, new Error(nameof(ValidationApiException))));
        }
        catch (Exception)
        {
            throw;
        }
    }
}