using Real_time_weather_monitoring_and_reporting_service.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;
using WeatherMonitoringSystem.Services;

namespace WeatherMonitoringSystem.Bots;

public class RainBot : IWeatherObserver
{
    private readonly HumidityBotConfiguration _config;

    public RainBot(HumidityBotConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        ConfigurationValidator.ValidateRainBot(_config);
    }

    public void Update(WeatherData data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (_config.Enabled != true)
            return;

        if (data.Humidity > _config.HumidityThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine($"RainBot: {_config.Message}");
        }
    }
}