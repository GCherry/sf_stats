using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Exceptions
{
    public class TeamSeasonPlayerException : SFStatsExceptionBase
    {
        public TeamSeasonPlayerException() : base()
        {
        }

        public TeamSeasonPlayerException(string message) : base(message)
        {
        }

        public TeamSeasonPlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
