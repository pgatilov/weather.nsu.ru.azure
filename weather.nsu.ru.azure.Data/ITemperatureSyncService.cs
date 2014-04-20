using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// Provides synchronization of local cache to data origin.
    /// </summary>
    public interface ITemperatureSyncService
    {
        /// <summary>
        /// Stores current temperature in local cache.
        /// </summary>
        /// <returns>A task the represents the operation.</returns>
        Task SyncCurrentTemperature();
    }
}
