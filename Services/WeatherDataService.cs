using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Services;

public class WeatherDataService
{
    private readonly List<IWeatherObserver>_observers=new();

    public void Subscribe(IWeatherObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);
        if(!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IWeatherObserver observer)
    {
        _observers.Remove(observer);
    }

    public void UpdateWeather(WeatherData weatherData)
    {
        ArgumentNullException.ThrowIfNull(weatherData);
        foreach (var observer in _observers)
        {
            observer.Update(weatherData);
        }
    }
}