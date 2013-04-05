using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather.nsu.ru.azure.Data;

namespace weather.nsu.ru.azure.Models
{
    /// <summary>
    /// Represents a model for the main page.
    /// </summary>
    public class HomePageModel
    {
        /// <summary>
        /// Gets or sets the current temperature value.
        /// </summary>
        public Temperature CurrentTemperature { get; set; }
    }
}