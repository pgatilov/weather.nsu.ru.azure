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
        private readonly _temperatureHistoryRepository;

        public TemperatureSyncService(ITemperatureHistoryRepository temperatureHistoryRepository) 
        {
        }

        public Task SyncCurrentTemperature()
        {
            throw new NotImplementedException();
        }
    }
}
