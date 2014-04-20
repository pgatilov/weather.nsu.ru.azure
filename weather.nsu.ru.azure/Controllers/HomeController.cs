using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using weather.nsu.ru.azure.Data;
using weather.nsu.ru.azure.Models;

namespace weather.nsu.ru.azure.Controllers
{
    /// <summary>
    /// Provides actions for Home view
    /// </summary>
    public class HomeController : Controller
    {
        readonly ITemperatureProvider _temperatureProvider;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="temperatureProvider">A <see cref="ITemperatureProvider"/> instance.</param>
        public HomeController(ITemperatureProvider temperatureProvider) 
        {
            if (temperatureProvider == null) 
            {
                throw new ArgumentNullException("temperatureProvider");
            }

            _temperatureProvider = temperatureProvider;
        }

        /// <summary>
        /// Gets the default state of Home view.
        /// </summary>
        /// <returns><see cref="ActionResult"/></returns>
        public async Task<ActionResult> Index()
        {
            var temperature = await _temperatureProvider.GetCurrentTemperature();

            var model = new HomePageModel
            {
                CurrentTemperature = temperature.Temperature
            };

            return View(model);
        }

    }
}
