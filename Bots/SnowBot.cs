using Real_time_weather_monitoring_and_reporting_service.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Bots;

public class SnowBot:IWeatherObserver
{
    private readonly TemperatureBotConfiguration _config;

    public SnowBot(TemperatureBotConfiguration config)
    {
        _config = config?? throw new ArgumentNullException(nameof(config));
    }
    public void Update(WeatherData weatherData)
    {
        ArgumentNullException.ThrowIfNull(weatherData);
        if (!_config.Enabled)
            return;

        if (weatherData.Temperature < _config.TemperatureThreshold)
        {
            Console.WriteLine("SnowBot activated!");
            Console.WriteLine($"SnowBot: {_config.Message}");
        }
    }
}