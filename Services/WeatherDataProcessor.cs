using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Services;

public class WeatherDataProcessor
{
    private IWeatherDataParser _parser;
    
    public WeatherDataProcessor(IWeatherDataParser parser)
    {
        _parser = parser??
                  throw new ArgumentNullException(nameof(parser));
    }

    public void SetParser(IWeatherDataParser parser)
    {
        _parser = parser??
                  throw new ArgumentNullException(nameof(parser));;
    }
    
    public WeatherData Process(string input)
    {
        return _parser.Parse(input);
    }
}