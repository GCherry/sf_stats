using System;

namespace sf_stats.Domain.DomainObjects
{
    public class LogQueryFilter
    {
        public string Level { get; set; }
        public int? Top { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
