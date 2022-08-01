using System;

namespace sf_stats.Api.Exceptions
{
    public class PlayerStatException : SFStatsExceptionBase
    {
        public PlayerStatException() : base()
        {
        }

        public PlayerStatException(string message) : base(message)
        {
        }

        public PlayerStatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
