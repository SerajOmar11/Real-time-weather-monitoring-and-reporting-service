namespace Real_time_weather_monitoring_and_reporting_service.Configuration;

public class BotConfiguration
{
    public bool? Enabled { get; set; }
    public string? Message { get; set; }
}

public class HumidityBotConfiguration: BotConfiguration
{
    public decimal? HumidityThreshold { get; set; }
}

public class TemperatureBotConfiguration: BotConfiguration
{
    public decimal? TemperatureThreshold { get; set; }
}