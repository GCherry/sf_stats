using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class TeamSeason : DbEntity
    {
        public int TeamId { get; set; }
        public int SeasonId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Season Season { get; set; }
        public virtual List<TeamSeasonGame> TeamSeasonGames { get; set; }
        public virtual List<TeamSeasonPlayer> TeamSeasonPlayers { get; set; }
    }
}
