namespace Real_time_weather_monitoring_and_reporting_service.Models;

public class WeatherData
{
    public required string Location { get; init; }
    public decimal Temperature { get; init; }
    public decimal Humidity { get; init; }
}