using System;

namespace sf_stats.Domain.Dtos
{
    public class LogDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Exception { get; set; }
        public string LogEvent { get; set; }
    }
}
