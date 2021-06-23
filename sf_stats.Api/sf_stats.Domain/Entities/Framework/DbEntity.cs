using System;

namespace sf_stats.Domain.Entities
{
    public class DbEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
    }
}
