using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data.DataModel
{
    /// <summary>
    /// Represents a specific temperature measurement instance.
    /// </summary>
    public sealed class TemperatureMeasurement
    {
        /// <summary>
        /// The id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date and time when the measurement was taken.
        /// </summary>
        public DateTime Taken { get; set; }

        /// <summary>
        /// The temperature value.
        /// </summary>
        public TemperatureValue Value { get; set; }
    }
}
