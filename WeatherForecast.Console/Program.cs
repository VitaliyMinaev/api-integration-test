using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Console;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var startup = new Startup(configuration);

var services = new ServiceCollection();
startup.ConfigureServices(services);

var serviceProvider = services.BuildServiceProvider();
await startup.RunAsync(serviceProvider, args);