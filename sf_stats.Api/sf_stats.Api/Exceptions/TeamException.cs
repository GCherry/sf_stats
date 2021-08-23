using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Exceptions
{
    public class TeamException : SFStatsExceptionBase
    {
        public TeamException() : base()
        {
        }

        public TeamException(string message) : base(message)
        {
        }

        public TeamException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
