using Real_time_weather_monitoring_and_reporting_service.Configuration;

namespace WeatherMonitoringSystem.Services;

public static class ConfigurationValidator
{
    public static void Validate(WeatherBotSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        ValidateBot("RainBot", settings.RainBot);
        ValidateBot("SunBot", settings.SunBot);
        ValidateBot("SnowBot", settings.SnowBot);

        ValidateHumidityThreshold(settings.RainBot!.HumidityThreshold);
        ValidateTemperatureThreshold("SunBot", settings.SunBot!.TemperatureThreshold);
        ValidateTemperatureThreshold("SnowBot", settings.SnowBot!.TemperatureThreshold);
    }

    private static void ValidateBot(string botName, BotConfiguration? config)
    {
        if (config is null)
            throw new ArgumentException($"{botName} configuration is missing.");

        if (config.Enabled is null)
            throw new ArgumentException($"{botName} enabled setting is missing.");

        if (string.IsNullOrWhiteSpace(config.Message))
            throw new ArgumentException($"{botName} message cannot be empty.");
    }

    private static void ValidateHumidityThreshold(decimal? threshold)
    {
        if (threshold is null || threshold < 0 || threshold > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(threshold), 
                "RainBot humidity threshold must be between 0 and 100.");
        }
    }

    private static void ValidateTemperatureThreshold(string botName, decimal? threshold)
    {
        if (threshold is null)
            throw new ArgumentException($"{botName} temperature threshold is missing.");
    }
    
    public static void ValidateRainBot(HumidityBotConfiguration config)
    {
        ValidateBot("RainBot", config);
        ValidateHumidityThreshold(config.HumidityThreshold);
    }

    public static void ValidateSunBot(TemperatureBotConfiguration config)
    {
        ValidateBot("SunBot", config);
        ValidateTemperatureThreshold("SunBot", config.TemperatureThreshold);
    }

    public static void ValidateSnowBot(TemperatureBotConfiguration config)
    {
        ValidateBot("SnowBot", config);
        ValidateTemperatureThreshold("SnowBot", config.TemperatureThreshold);
    }
}