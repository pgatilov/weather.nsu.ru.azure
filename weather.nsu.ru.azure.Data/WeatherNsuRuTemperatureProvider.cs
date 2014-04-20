using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Common.Extensions;

namespace weather.nsu.ru.azure.Data
{
    class WeatherNsuRuTemperatureProvider : ITemperatureDataSource
    {
        readonly IWeatherNsuRuTemperatureParser _parser;
        readonly Random _random = new Random();

        public WeatherNsuRuTemperatureProvider(IWeatherNsuRuTemperatureParser parser) 
        {
            if (parser == null) 
            {
                throw new ArgumentNullException("parser");
            }

            _parser = parser;
        }

        public async Task<TemperatureMeasurementRecord> GetCurrentTemperature()
        {
            var requestUrlString = string.Format(CultureInfo.InvariantCulture, "/loadata.php?tick={0}&rand={1}&std=three", DateTime.UtcNow.ToUnixEpoch(), _random.NextDouble());

            string dataString;
            DateTimeOffset? date;
            using (var http = CreateHttpClient())
            {
                var sw = Stopwatch.StartNew();
                var message = await http.GetAsync(requestUrlString);
                sw.Stop();
                Trace.TraceInformation("weather.nsu.ru responded in {0} ms", sw.ElapsedMilliseconds);

                dataString = await message.Content.ReadAsStringAsync();
                date = message.Headers.Date;
            }

            var measurementDate = date.HasValue ? date.Value.UtcDateTime : DateTime.UtcNow;

            var temperature = _parser.ParseCurrentTemperature(dataString);
            return new TemperatureMeasurementRecord(temperature, measurementDate);
        }

        private static HttpClient CreateHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = Properties.Settings.Default.SourceBaseUri,
                
            };
        }
    }
}
