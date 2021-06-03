using System;

namespace sf_stats.Api.Exceptions
{
    public class SFStatsExceptionBase : Exception
    {
        public SFStatsExceptionBase()
        {
        }

        public SFStatsExceptionBase(string message) : base(message)
        {
        }

        public SFStatsExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
