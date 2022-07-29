using System;

namespace sf_stats.Domain.Dtos
{
    public class SeasonDto : IDto
    {
        public int DivisionId { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
    }
}
