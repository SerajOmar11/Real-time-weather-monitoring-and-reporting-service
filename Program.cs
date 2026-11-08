using System.Text.Json;
using System.Xml;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;
using Real_time_weather_monitoring_and_reporting_service.Parsers;
using Real_time_weather_monitoring_and_reporting_service.Services;
using WeatherMonitoringSystem.Bots;
using WeatherMonitoringSystem.Services;

try
{
    ConfigurationService configurationService = new();
    string configPath = Path.Combine(AppContext.BaseDirectory, "BotsSettings.json");

    var settings = configurationService.Load(configPath);

    WeatherDataService weatherService = new();

    if (settings.RainBot!.Enabled == true)
        weatherService.Subscribe(new RainBot(settings.RainBot));

    if (settings.SunBot!.Enabled == true)
        weatherService.Subscribe(new SunBot(settings.SunBot));

    if (settings.SnowBot!.Enabled == true)
        weatherService.Subscribe(new SnowBot(settings.SnowBot));

    WeatherParserResolver parserResolver = new();

    parserResolver.Register(new JsonWeatherParser());
    parserResolver.Register(new XmlWeatherParser());

    WeatherDataProcessor processor = new(new JsonWeatherParser());

    Console.WriteLine("==================================");
    Console.WriteLine("     WEATHER MONITORING SYSTEM    ");
    Console.WriteLine("==================================");

    Console.WriteLine("Supported formats: JSON, XML");
    Console.WriteLine("Type 'exit' to close the application.");

    while (true)
    {
        Console.WriteLine();
        Console.Write("Enter weather data: ");

        string? input = Console.ReadLine();

        if (input is null || input.Trim().Equals("exit",StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Exiting Weather Monitoring System...");
            break;
        }

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Weather data cannot be empty.");
            continue;
        }

        try
        {
            IWeatherDataParser parser = parserResolver.Resolve(input);

            processor.SetParser(parser);

            WeatherData weather = processor.Process(input);

            Console.WriteLine();
            Console.WriteLine("Weather update received successfully!");
            Console.WriteLine($"Location: {weather.Location}");
            Console.WriteLine($"Temperature: {weather.Temperature}°C");
            Console.WriteLine($"Humidity: {weather.Humidity}%");

            Console.WriteLine();

            weatherService.UpdateWeather(weather);
        }
        catch (Exception ex) when (
            ex is JsonException or
            XmlException or
            FormatException or
            ArgumentException or
            NotSupportedException)
        {
            Console.WriteLine($"Invalid weather data: {ex.Message}");
        }
    }
}
catch (Exception ex) when (
    ex is IOException or
    JsonException or
    ArgumentException)
{
    Console.WriteLine($"Application startup failed: {ex.Message}");
}