using Real_time_weather_monitoring_and_reporting_service.Models;

namespace WeatherMonitoringSystem.Services;

public static class WeatherDataValidator
{
    public static void Validate(WeatherData data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (string.IsNullOrWhiteSpace(data.Location))
            throw new ArgumentException("Location cannot be null, empty, or whitespace.", nameof(data.Location));

        if (data.Humidity < 0 || data.Humidity > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(data.Humidity), "Humidity must be between 0 and 100.");
        }
    }
}