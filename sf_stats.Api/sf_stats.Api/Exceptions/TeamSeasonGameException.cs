using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Exceptions
{
    public class TeamSeasonGameException : SFStatsExceptionBase
    {
        public TeamSeasonGameException() : base()
        {
        }

        public TeamSeasonGameException(string message) : base(message)
        {
        }

        public TeamSeasonGameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
