using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using WeatherForecast.Console.Contracts.Api;
using WeatherForecast.Console.Options;
using WeatherForecast.Console.Output;
using WeatherForecast.Console.Services;
using WeatherForecast.Console.Validators;

namespace WeatherForecast.Console;

public class Startup
{
    public IConfiguration Configuration { get; init; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var options = new ApiOptions();
        Configuration.GetSection(ApiOptions.Section).Bind(options);

        services.AddRefitClient<IWeatherForecastApi>()
            .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new []
            {
                TimeSpan.FromSeconds(1), 
                TimeSpan.FromSeconds(3), 
                TimeSpan.FromSeconds(6)
            }))
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(options.Url);
            });
        
        services.AddTransient<IWeatherForecastSearchService, WeatherForecastSearchService>();
        services.AddValidatorsFromAssemblyContaining<ForecastSearchRequestValidator>();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<WeatherForecastSearchApplication>();
    }

    public async Task RunAsync(IServiceProvider serviceProvider, string[] args)
    {
        var app = serviceProvider.GetRequiredService<WeatherForecastSearchApplication>();
        await app.RunAsync(args);
    }
}