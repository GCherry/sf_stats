using System;
using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Game : DbEntity
    {
        public DateTime GameDate { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }

        public virtual List<TeamSeasonGame> TeamSeasonGames { get; set; }

        public List<PlayerStat> PlayerStats { get; set; }
    }
}
