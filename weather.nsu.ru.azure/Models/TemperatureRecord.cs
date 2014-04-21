using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather.nsu.ru.azure.Data;

namespace weather.nsu.ru.azure.Models
{
    public class TemperatureChartPoint
    {
        public DateTime Taken { get; set; }

        public float Temperature { get; set; }

        public Unit Unit { get; set; }
    }
}