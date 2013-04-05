using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.nsu.ru.azure.Common.Extensions
{
    /// <summary>
    /// Contains extensions for <see cref="DateTime"/> class.
    /// </summary>
    public static class DateTimeExtensions
    {
        static readonly DateTime _UnixEpochZero = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixEpoch(this DateTime dateTime)
        {
            var utc = dateTime.ToUniversalTime();

            var from1970 = utc - _UnixEpochZero;

            var totalSeconds = from1970.TotalSeconds;

            var fullSeconds = Math.Floor(totalSeconds);
            if (fullSeconds > long.MaxValue) 
            {
                throw new ArgumentOutOfRangeException("dateTime", dateTime, "The value is too big.");
            }
            if (fullSeconds < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("dateTime", dateTime, "The value is too small.");
            }

            return (long)fullSeconds;
        }
    }
}
