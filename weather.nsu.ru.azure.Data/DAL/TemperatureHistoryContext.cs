using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Data.DataModel;

namespace weather.nsu.ru.azure.Data.DAL
{
    public class TemperatureHistoryContext : DbContext
    {
        public TemperatureHistoryContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual IDbSet<TemperatureMeasurement> TemperatureMeasurements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<TemperatureValue>();
            modelBuilder.Entity<TemperatureMeasurement>();
        }
    }
}
