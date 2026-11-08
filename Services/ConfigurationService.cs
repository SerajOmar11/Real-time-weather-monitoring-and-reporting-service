using System.Net;
using System.Text.Json;
using Real_time_weather_monitoring_and_reporting_service.Configuration;

namespace Real_time_weather_monitoring_and_reporting_service.Services;

public class ConfigurationService
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public WeatherBotSettings Load(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        if (!File.Exists(filePath))
            throw new FileNotFoundException("Configuration file not found", filePath);
        
        string json= File.ReadAllText(filePath);
        WeatherBotSettings? settings = JsonSerializer.Deserialize<WeatherBotSettings>(json, _options);
        return settings??throw new JsonException("Invalid configuration file");
    }
}