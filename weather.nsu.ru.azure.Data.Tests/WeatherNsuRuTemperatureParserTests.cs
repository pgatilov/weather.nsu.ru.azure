using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data.Tests
{
    [TestClass]
    public class WeatherNsuRuTemperatureParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseCurrentTemperature_ThrowsOnNull() 
        {
            new WeatherNsuRuTemperatureParser().ParseCurrentTemperature(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseCurrentTemperature_ThrowsOnEmptyString()
        {
            new WeatherNsuRuTemperatureParser().ParseCurrentTemperature("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseCurrentTemperature_ThrowsOnWhitespaceString()
        {
            new WeatherNsuRuTemperatureParser().ParseCurrentTemperature("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataSourceException))]
        public void ParseCurrentTemperature_ThrowsIfCannotFindCurrentTemperatureString()
        {
            new WeatherNsuRuTemperatureParser().ParseCurrentTemperature(@"
id = 'temp';
cnv = document.all? (document.all[id] || null)
        : document.getElementById? (document.getElementById(id) || null)
        : null;
window.document.title = 'Температура около НГУ 0.6 C';

id = 'avertemp';
cnv = document.all? (document.all[id] || null)
        : document.getElementById? (document.getElementById(id) || null)
        : null;
if(cnv) cnv.innerHTML = '-2.5&deg;C';

graph.paint();
");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataSourceException))]
        public void ParseCurrentTemperature_ThrowsIfCannotParseTemperatureValueString()
        {
            new WeatherNsuRuTemperatureParser().ParseCurrentTemperature(@"
id = 'temp';
cnv = document.all? (document.all[id] || null)
        : document.getElementById? (document.getElementById(id) || null)
        : null;
if(cnv) cnv.innerHTML = '0.623523452345234523452345234523452345&deg;C';
window.document.title = 'Температура около НГУ 0.6 C';

id = 'avertemp';
cnv = document.all? (document.all[id] || null)
        : document.getElementById? (document.getElementById(id) || null)
        : null;
if(cnv) cnv.innerHTML = '-2.5&deg;C';

graph.paint();
");
        }

        [TestMethod]
        public void ParseCurrentTemperature_ParsesRealResponse()
        {
            var temperature = new WeatherNsuRuTemperatureParser().ParseCurrentTemperature(@"
id = 'temp';
cnv = document.all? (document.all[id] || null)
        : document.getElementById? (document.getElementById(id) || null)
        : null;
if(cnv) cnv.innerHTML = '0.6&deg;C';
window.document.title = 'Температура около НГУ 0.6 C';

id = 'avertemp';
cnv = document.all? (document.all[id] || null)
        : document.getElementById? (document.getElementById(id) || null)
        : null;
if(cnv) cnv.innerHTML = '-2.5&deg;C';

graph.paint();
");

            Assert.IsNotNull(temperature);
            Assert.AreEqual(0.6, temperature.Value);
            Assert.AreEqual(Unit.Celsius, temperature.Unit);
        }
    }
}
