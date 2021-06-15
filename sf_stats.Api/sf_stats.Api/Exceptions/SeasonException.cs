using System;

namespace sf_stats.Api.Exceptions
{
    public class SeasonException : SFStatsExceptionBase
    {
        public SeasonException() : base()
        {
        }

        public SeasonException(string message) : base(message)
        {
        }

        public SeasonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
