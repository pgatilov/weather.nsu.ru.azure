﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data.DAL
{
    internal interface ITemperatureHistoryRepository
    {
        Task<TemperatureMeasurementRecord> GetLastTemperatureRecord(DateTime? dateFrom = null, DateTime? dateTo = null);

        Task StoreTemperatureMeasurement(TemperatureMeasurementRecord record);
    }
}
