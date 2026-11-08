namespace Real_time_weather_monitoring_and_reporting_service.Configuration;

public class WeatherBotSettings
{
    public HumidityBotConfiguration RainBot { get; set; } = new();
    public TemperatureBotConfiguration SunBot { get; set; } = new();
    public TemperatureBotConfiguration SnowBot { get; set; } = new();
}