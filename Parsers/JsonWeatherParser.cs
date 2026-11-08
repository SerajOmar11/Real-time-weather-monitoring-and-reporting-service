using System.Text.Json;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Parsers;

public class JsonWeatherParser:IWeatherDataParser
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public WeatherData Parse(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        WeatherData? weatherData = JsonSerializer.Deserialize<WeatherData>(input, _options);
        return weatherData??throw new JsonException("Invalid Weather JSON data");
    }

    public bool CanParse(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);
        return input.Trim().StartsWith("{");
    }
}