using sf_stats.Domain.Entities;
using System;

namespace sf_stats.Domain.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public int Home_TeamSeasonId { get; set; }
        public int Aaway_TeamSeasonId { get; set; }
        public int DivisionId { get; set; }
        public DateTime GameDate { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }
    }
}
