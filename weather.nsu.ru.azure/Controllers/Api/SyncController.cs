using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace weather.nsu.ru.azure.Controllers.Api
{
    public class SyncController : ApiController
    {
        private readonly ITemperatureSyncService _temperatureSyncService;

        public SyncController(ITemperatureSyncService temperatureSyncService) 
        {
            if (temperatureSyncService == null) 
            {
                throw new ArgumentNullException("temperatureSyncService");
            }

            _temperatureSyncService = temperatureSyncService;
        }
    }
}