using System;
using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Game : DbEntity
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public int Home_TeamSeasonId { get; set; }
        public int Away_TeamSeasonId { get; set; }
        public DateTime GameDate { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }

        public virtual TeamSeason Home_TeamSeason { get; set; }
        public virtual TeamSeason Away_TeamSeason { get; set; }
        public virtual Division Division { get; set; }
        public virtual List<PlayerStat> PlayerStats {get; set;}
    }
}
