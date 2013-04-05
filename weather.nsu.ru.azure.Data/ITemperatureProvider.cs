using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// Provides temperature data.
    /// </summary>
    public interface ITemperatureProvider
    {
        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        /// <returns>A task that returns the current temperature value.</returns>
        Task<Temperature> GetCurrentTemperature();
    }
}
