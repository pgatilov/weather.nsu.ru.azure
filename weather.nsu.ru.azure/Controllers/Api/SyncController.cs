using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using weather.nsu.ru.azure.Data;

namespace weather.nsu.ru.azure.Controllers.Api
{
    /// <summary>
    /// Provides synchronization control API.
    /// </summary>
    public class SyncController : ApiController
    {
        private readonly ITemperatureSyncService _temperatureSyncService;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="temperatureSyncService">
        /// A reference to <see cref="ITemperatureSyncService"/>.
        /// </param>
        public SyncController(ITemperatureSyncService temperatureSyncService) 
        {
            if (temperatureSyncService == null) 
            {
                throw new ArgumentNullException("temperatureSyncService");
            }

            _temperatureSyncService = temperatureSyncService;
        }

        /// <summary>
        /// Runs synchronization jobs.
        /// </summary>
        /// <returns>
        /// A task that represents the process.
        /// </returns>
        [HttpPost]
        public async Task RunSync() 
        {
            await _temperatureSyncService.SyncCurrentTemperature();
        }
    }
}