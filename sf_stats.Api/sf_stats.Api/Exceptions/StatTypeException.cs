using System;

namespace sf_stats.Api.Exceptions
{
    public class StatTypeException : SFStatsExceptionBase
    {
        public StatTypeException() : base()
        {
        }

        public StatTypeException(string message) : base(message)
        {
        }

        public StatTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
