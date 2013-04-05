using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Data
{
    /// <summary>
    /// Represents an error in data received from a data source.
    /// </summary>
    public class InvalidDataSourceException : Exception
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public InvalidDataSourceException() : base() { }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        public InvalidDataSourceException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException"> Inner exception.</param>
        public InvalidDataSourceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
