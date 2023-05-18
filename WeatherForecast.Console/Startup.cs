using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using WeatherForecast.Console.Contracts.Api;
using WeatherForecast.Console.Options;
using WeatherForecast.Console.Output;

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
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(options.Url);
            });

        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<WeatherForecastSearchApplication>();
    }

    public async Task RunAsync(IServiceProvider serviceProvider, string[] args)
    {
        var app = serviceProvider.GetRequiredService<WeatherForecastSearchApplication>();
        await app.RunAsync(args);
    }
}