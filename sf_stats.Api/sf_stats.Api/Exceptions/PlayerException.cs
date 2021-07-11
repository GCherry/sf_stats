using System;

namespace sf_stats.Api.Exceptions
{
    public class PlayerException : SFStatsExceptionBase
    {
        public PlayerException() : base()
        {
        }

        public PlayerException(string message) : base(message)
        {
        }

        public PlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
