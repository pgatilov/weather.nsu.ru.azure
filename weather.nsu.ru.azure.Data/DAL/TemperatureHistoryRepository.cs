using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Data.DataModel;

namespace weather.nsu.ru.azure.Data.DAL
{
    internal class TemperatureHistoryRepository : ITemperatureHistoryRepository
    {
        private readonly TemperatureHistoryContext _context = new TemperatureHistoryContext("DefaultConnection");

        public async Task<Temperature?> GetLastTemperatureRecord(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var query = _context.TemperatureMeasurements.AsQueryable();

            if (dateFrom.HasValue)
                query = query.Where(x => x.Taken >= dateFrom.Value);

            if (dateTo.HasValue)
                query = query.Where(x => x.Taken <= dateTo.Value);

            var lastMeasurement = await query.FirstOrDefaultAsync();
            return lastMeasurement != null 
                ? new Temperature(lastMeasurement.Value.Value, lastMeasurement.Value.Unit) 
                : (Temperature?)null;
        }


        public Task StoreTemperatureMeasurement(Temperature currentTemperature, DateTime dateTime)
        {
            var newRecord = new TemperatureMeasurement
            {
                Taken = dateTime,
                Value = new TemperatureValue
                {
                    Unit = currentTemperature.Unit,
                    Value = (float)currentTemperature.Value
                }
            };


        }
    }
}
