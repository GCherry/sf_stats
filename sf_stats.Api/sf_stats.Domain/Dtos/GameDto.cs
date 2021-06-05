using sf_stats.Domain.Entities;
using System;

namespace sf_stats.Domain.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int DivisionId { get; set; }
        public int Home_TeamId { get; set; }
        public int Away_TeamId { get; set; }
        public DateTime GameDate { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }

        public virtual Season Season { get; set; }
        public virtual Division Division { get; set; }
        public virtual Team Home_Team { get; set; }
        public virtual Team Away_Team { get; set; }
    }
}
