using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Data.DataModel;

namespace weather.nsu.ru.azure.Data.DAL
{
    /// <summary>
    /// EF context for temperature history DB
    /// </summary>
    public class TemperatureHistoryContext : DbContext
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="connectionString">Connection string or config name.</param>
        public TemperatureHistoryContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// The set of <see cref="TemperatureMeasurement"/> objects.
        /// </summary>
        public virtual IDbSet<TemperatureMeasurement> TemperatureMeasurements { get; set; }

        /// <summary>
        /// Configures the model
        /// </summary>
        /// <param name="modelBuilder">Model builder to use.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<TemperatureValue>();
            modelBuilder.Entity<TemperatureMeasurement>();
        }
    }
}
