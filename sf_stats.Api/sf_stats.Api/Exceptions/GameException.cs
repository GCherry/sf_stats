using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Exceptions
{
    public class GameException : SFStatsExceptionBase
    {
        public GameException() : base()
        {
        }

        public GameException(string message) : base(message)
        {
        }

        public GameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
