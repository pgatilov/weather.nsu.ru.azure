using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    public interface ITemperatureSyncService
    {
        Task SyncCurrentTemperature();
    }
}
