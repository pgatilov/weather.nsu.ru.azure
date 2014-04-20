using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// Represents a temperature value measurement.
    /// </summary>
    public class TemperatureMeasurementRecord
    {
        private readonly Temperature _temperature;
        private readonly DateTime _taken;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="taken">The time the temperature was taken.</param>
        public TemperatureMeasurementRecord(Temperature temperature, DateTime taken) 
        {
            _taken = taken;
            _temperature = temperature;
        }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        public Temperature Temperature { get { return _temperature; } }

        /// <summary>
        /// Gets the time the measurement was taken.
        /// </summary>
        public DateTime Taken { get { return _taken; } }
    }
}
