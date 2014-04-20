using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data.DataModel
{
    /// <summary>
    /// Represents a temperature value. Complex type.
    /// </summary>
    public sealed class TemperatureValue
    {
        /// <summary>
        /// The value.
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// The unit of measurement.
        /// </summary>
        public Unit Unit { get; set; }
    }
}
