using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Common.Autofac;
using weather.nsu.ru.azure.Data.DAL;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// Configures Data module components.
    /// </summary>
    public class DataModule : Module
    {
        /// <summary>
        /// Adds DAL module components registrations.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WeatherNsuRuTemperatureProvider>().AsImplementedInterfaces()
                .FindConstructorsWith(AnyConstructorFinder.Instance);

            builder.RegisterType<WeatherNsuRuTemperatureParser>().AsImplementedInterfaces()
                .FindConstructorsWith(AnyConstructorFinder.Instance);

            builder.RegisterDecorator<ITemperatureProvider>(
                (ctx, p) => new CachedTemperatureProvider(ctx.Resolve<ITemperatureHistoryRepository>(), p),
                typeof (ITemperatureProvider))
                .As<ITemperatureProvider>();

            builder.RegisterType<TemperatureHistoryRepository>().AsImplementedInterfaces()
        }
    }
}
