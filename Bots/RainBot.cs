using Real_time_weather_monitoring_and_reporting_service.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Bots;

public class RainBot:IWeatherObserver
{
    private readonly HumidityBotConfiguration _config;

    public RainBot(HumidityBotConfiguration config)
    {
        _config = config?? throw new ArgumentNullException(nameof(config));
    }
    public void Update(WeatherData weatherData)
    {
        ArgumentNullException.ThrowIfNull(weatherData);
        if (!_config.Enabled)
            return;

        if (weatherData.Humidity > _config.HumidityThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine($"RainBot: {_config.Message}");
        }
    }
}