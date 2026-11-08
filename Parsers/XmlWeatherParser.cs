using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Models;

namespace Real_time_weather_monitoring_and_reporting_service.Parsers;

public class XmlWeatherParser:IWeatherDataParser
{
    public WeatherData Parse(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        XDocument document = XDocument.Parse(input);
        XElement root = document.Root ?? throw new XmlException("Missing XML root element");

        if (root.Name != "WeatherData")
            throw new FormatException("Expected a WeatherData root element");

        string location = (string?)root.Element("Location") ?? 
                          throw new FormatException("Location is missing");
        
        decimal temperature = decimal.Parse(
            (string?)root.Element("Temperature")
            ?? throw new FormatException("Temperature is missing."),
            CultureInfo.InvariantCulture);

        decimal humidity = decimal.Parse(
            (string?)root.Element("Humidity")
            ?? throw new FormatException("Humidity is missing."),
            CultureInfo.InvariantCulture);

        return new WeatherData()
        {
            Location = location,
            Temperature = temperature,
            Humidity = humidity
        };
    }
    
    public bool CanParse(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);
        return input.Trim().StartsWith("<");
    }
}