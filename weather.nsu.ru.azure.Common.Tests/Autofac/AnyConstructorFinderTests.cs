using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using weather.nsu.ru.azure.Common.Autofac;

namespace weather.nsu.ru.azure.Common.Tests.Autofac
{
    [TestClass]
    public class AnyConstructorFinderTests
    {
        [TestMethod]
        public void Instance_NotNull() 
        {
            var instance = AnyConstructorFinder.Instance;

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void Instance_AlwaysReturnsSameObject() 
        {
            var objects = Enumerable.Range(0, 1000000)
                .Select(_ => AnyConstructorFinder.Instance);

            Assert.IsTrue(objects.Distinct().Count() == 1);
        }

        [TestMethod]
        public void Instance_ThreadSafe()
        {

            using (var gate = new Barrier(5))
            {
                var result = new ConcurrentBag<AnyConstructorFinder>();

                Action test = () =>
                {
                    gate.SignalAndWait(20);

                    var instance = AnyConstructorFinder.Instance;

                    Thread.MemoryBarrier();

                    result.Add(instance);
                };

                var cycleState = Parallel.For(0, 200,
                    new ParallelOptions { MaxDegreeOfParallelism = 15 },
                    x => { test(); })
                    ;

                while (!cycleState.IsCompleted) 
                {
                    Thread.Sleep(100);
                }

                Assert.IsTrue(result.All(x => x != null));
                Assert.IsTrue(result.Distinct().Count() == 1);
            }
        }

        [TestMethod]
        public void FindConstructors_ReturnsInternalConstructors() 
        {
            var finder = new AnyConstructorFinder();

            var result = finder.FindConstructors(typeof(X));

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            var constructor = typeof(X)
                .GetConstructor(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null, new[] { typeof(int) }, null);
            CollectionAssert.Contains(result, constructor);
        }

        public class X
        {
            public X()
            {
            }

            internal X(int a)
            {
            }
        }
    }
}
