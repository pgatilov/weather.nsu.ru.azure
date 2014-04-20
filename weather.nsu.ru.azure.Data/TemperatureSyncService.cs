using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Data.DAL;

namespace weather.nsu.ru.azure.Data
{
    internal class TemperatureSyncService : ITemperatureSyncService
    {
        private static readonly TimeSpan CacheSyncInterval = TimeSpan.FromMinutes(1);

        private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;
        private readonly ITemperatureDataSource _temperatureDataSource;

        public TemperatureSyncService(ITemperatureHistoryRepository temperatureHistoryRepository, ITemperatureDataSource temperatureDataSource) 
        {
            if (temperatureHistoryRepository == null) 
            {
                throw new ArgumentNullException("temperatureHistoryRepository");
            }

            if (temperatureDataSource == null) 
            {
                throw new ArgumentNullException("temperatureDataSource");
            }

            _temperatureHistoryRepository = temperatureHistoryRepository;
            _temperatureDataSource = temperatureDataSource;
        }

        public async Task SyncCurrentTemperature()
        {
            var now = DateTime.UtcNow;
            var lastCachedRecord = await _temperatureHistoryRepository.GetLastTemperatureRecord(now - CacheSyncInterval);
            if (lastCachedRecord != null) 
            {
                return;
            }

            var currentTemperature = await _temperatureDataSource.GetCurrentTemperature();

            await _temperatureHistoryRepository.StoreTemperatureMeasurement(currentTemperature);
        }
    }
}
