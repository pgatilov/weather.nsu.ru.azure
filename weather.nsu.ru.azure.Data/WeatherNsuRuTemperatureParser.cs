using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    class WeatherNsuRuTemperatureParser : IWeatherNsuRuTemperatureParser
    {
        public Temperature ParseCurrentTemperature(string dataString)
        {
            if (dataString == null) 
            {
                throw new ArgumentNullException("dataString");
            }
            if (string.IsNullOrWhiteSpace(dataString)) 
            {
                throw new ArgumentException("Non-empty string is required", "dataString");
            }

            const string temperatureGroupName = "temperature";
            var pattern = string.Format(@"if\s*\(\s*cnv\s*\)\s+cnv.innerHTML\s+=\s+'(?<{0}>(\+|-)?\d+\.\d+)&deg;C';", temperatureGroupName);
            var match = Regex.Match(dataString, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

            if (!match.Success)
            {
                throw new InvalidDataSourceException("Cannot parse current temperature");
            }

            var temperatureGroup = match.Groups[temperatureGroupName];
            if (!temperatureGroup.Success)
            {
                throw new InvalidDataSourceException("Cannot parse current temperature");
            }

            var temperatureValueString = temperatureGroup.Value;
            double temperature;
            var culture = CultureInfo.GetCultureInfoByIetfLanguageTag("en-us");
            if (!double.TryParse(temperatureValueString, NumberStyles.Number, culture, out temperature))
            {
                throw new InvalidDataSourceException(string.Format("Cannot parse current temperature: cannot parse value '{0}'", temperatureValueString));
            }

            return new Temperature(temperature, Unit.Celsius);
        }
    }
}
