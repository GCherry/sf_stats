using System;

namespace sf_stats.Api.Exceptions
{
    public class DivisionException : SFStatsExceptionBase
    {
        public DivisionException() : base()
        {
        }

        public DivisionException(string message) : base(message)
        {
        }

        public DivisionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
