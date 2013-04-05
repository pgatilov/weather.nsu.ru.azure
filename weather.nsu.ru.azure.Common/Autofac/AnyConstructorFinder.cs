using Autofac.Core.Activators.Reflection;
using System;
using System.Reflection;
using System.Threading;

namespace weather.nsu.ru.azure.Common.Autofac
{
    public sealed class AnyConstructorFinder : IConstructorFinder
    {
        static readonly Lazy<AnyConstructorFinder> _Instance =
            new Lazy<AnyConstructorFinder>(() => new AnyConstructorFinder(), LazyThreadSafetyMode.PublicationOnly);

        public static AnyConstructorFinder Instance { get { return _Instance.Value; } }

        public ConstructorInfo[] FindConstructors(Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException("targetType");

            return targetType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}
