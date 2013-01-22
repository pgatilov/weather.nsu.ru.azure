using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace weather.nsu.ru.azure.Controllers
{
    /// <summary>
    /// Provides actions for Home view
    /// </summary>
    public class HomeController : Controller
    {
        //
        // GET: /Index/

        /// <summary>
        /// Gets the default state of Home view.
        /// </summary>
        /// <returns><see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
