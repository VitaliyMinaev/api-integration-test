namespace WeatherForecast.Console.Output;

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string input)
    {
        System.Console.WriteLine(input);
    }
}