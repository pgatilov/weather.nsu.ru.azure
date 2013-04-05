using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    interface IWeatherNsuRuTemperatureParser
    {
        /// <summary>
        /// Parses current temperature value from a http://weather.nsu.ru/loadata.php call result.
        /// </summary>
        /// <param name="dataString">The data string.</param>
        /// <returns>The value of the current temperature.</returns>
        /// <exception cref="InvalidDataSourceException">
        /// Thrown if current temperature cannot be parsed.
        /// </exception>
        Temperature ParseCurrentTemperature(string dataString);
    }
}
