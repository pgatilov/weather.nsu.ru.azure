using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data.DataModel
{
    public sealed class TemperatureMeasurement
    {
        public int Id { get; set; }

        public DateTime Taken { get; set; }

        public TemperatureValue Value { get; set; }
    }
}
