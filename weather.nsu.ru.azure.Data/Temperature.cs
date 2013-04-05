using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// Represents a temperature value.
    /// </summary>
    public struct Temperature
    {
        private readonly double _value;
        private readonly Unit _unit;

        /// <summary>
        /// Creates a new temperature value.
        /// </summary>
        /// <param name="value">The absolute value.</param>
        /// <param name="unit">The unit of measure.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="unit"/> is <see cref="Data.Unit.Undetermined"/>
        /// </exception>
        public Temperature(double value, Unit unit)
        {
            if (unit == Unit.Undetermined)
                throw new ArgumentOutOfRangeException("unit", unit, "Unit must be determined");

            _value = value;
            _unit = unit;
        }

        /// <summary>
        /// Gets the absolute value.
        /// </summary>
        public double Value { get { return this._value; } }

        /// <summary>
        /// Gets the unit of measure.
        /// </summary>
        public Unit Unit { get { return this._unit; } }

        /// <summary>
        /// Gets a string representation of the object.
        /// </summary>
        /// <returns>A string that represents the temperature value.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:F1} {1}", _value, GetDisplayString(_unit));
        }

        private string GetDisplayString(Unit unit)
        {
            switch(unit)
            {
                case Unit.Celsius:
                    return "\u00B0C";
                case Unit.Undetermined:
                    return "?";
                default:
                    throw new ArgumentOutOfRangeException("unit", unit, "Unexpected value encountered");
            }
        }
    }
}
