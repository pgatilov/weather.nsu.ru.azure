﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data.DataModel
{
    public sealed class TemperatureValue
    {
        public float Value { get; set; }

        public Unit Unit { get; set; }
    }
}
