using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Exceptions
{
    public class TeamSeasonException : SFStatsExceptionBase
    {
        public TeamSeasonException() : base()
        {
        }

        public TeamSeasonException(string message) : base(message)
        {
        }

        public TeamSeasonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
