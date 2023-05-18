using FluentValidation;
using WeatherForecast.Console.Domain;

namespace WeatherForecast.Console.Validators;

public class ForecastSearchRequestValidator : AbstractValidator<ForecastSearchRequest>
{
    public ForecastSearchRequestValidator()
    {
        RuleFor(x => x.Region)
            .NotEmpty()
            .MinimumLength(3);
    }
}