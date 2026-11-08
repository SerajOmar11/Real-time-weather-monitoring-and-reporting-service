using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces;

public interface IWeatherObserver
{
    void Update(WeatherData weatherData);
}