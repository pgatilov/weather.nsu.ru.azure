using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Data.DAL;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// An implementation of <see cref="ITemperatureProvider"/> that first pulls data from local cache, then falls back to original source.
    /// </summary>
    public class CachedTemperatureProvider : ITemperatureProvider
    {
        private static readonly TimeSpan CachedCurrentTemperatureExpiration = TimeSpan.FromMinutes(5);

        private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;
        private readonly ITemperatureProvider _fallbackProvider;

        internal CachedTemperatureProvider(ITemperatureHistoryRepository temperatureHistoryRepository,
            ITemperatureProvider fallbackProvider)
        {
            if (temperatureHistoryRepository == null) throw new ArgumentNullException("temperatureHistoryRepository");
            if (fallbackProvider == null) throw new ArgumentNullException("fallbackProvider");

            _temperatureHistoryRepository = temperatureHistoryRepository;
            _fallbackProvider = fallbackProvider;
        }

        /// <summary>
        /// Retrieves record from cache if non stale exists, otherwise falls back to wrapped provider.
        /// </summary>
        /// <returns>A task that returns current temperature.</returns>
        public async Task<Temperature> GetCurrentTemperature()
        {
            var cachedRecord =
                await _temperatureHistoryRepository.GetLastTemperatureRecord(DateTime.UtcNow - CachedCurrentTemperatureExpiration);
            if (cachedRecord != null)
            {
                return cachedRecord.Value;
            }

            return await _fallbackProvider.GetCurrentTemperature();
        }
    }
}
