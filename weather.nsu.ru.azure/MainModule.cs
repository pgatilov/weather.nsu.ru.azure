using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather.nsu.ru.azure.Controllers;

namespace weather.nsu.ru.azure
{
    /// <summary>
    /// Configures Main module components.
    /// </summary>
    public class MainModule : Module
    {
        /// <summary>
        /// Adds main module components registrations.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(ThisAssembly);
        }
    }
}