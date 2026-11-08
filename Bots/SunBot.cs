using Real_time_weather_monitoring_and_reporting_service.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;
using WeatherMonitoringSystem.Services;

namespace WeatherMonitoringSystem.Bots;

public class SunBot : IWeatherObserver
{
    private readonly TemperatureBotConfiguration _config;

    public SunBot(TemperatureBotConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        ConfigurationValidator.ValidateSunBot(_config);
    }

    public void Update(WeatherData data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (_config.Enabled != true)
            return;

        if (data.Temperature > _config.TemperatureThreshold)
        {
            Console.WriteLine("SunBot activated!");
            Console.WriteLine($"SunBot: {_config.Message}");
        }
    }
}