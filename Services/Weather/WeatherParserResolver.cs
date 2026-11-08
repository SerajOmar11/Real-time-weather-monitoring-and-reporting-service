using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.Services;

public class WeatherParserResolver
{
    private readonly List<IWeatherDataParser> _parsers = new();

    public void Register(IWeatherDataParser Parser)
    {
        ArgumentNullException.ThrowIfNull(Parser);
        _parsers.Add(Parser);
    }

    public IWeatherDataParser Resolve(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        return _parsers.FirstOrDefault(parser => parser.CanParse(input))?? 
               throw new NotSupportedException("Unsupported weather data format");
    }
}