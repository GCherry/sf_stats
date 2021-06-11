using System;
using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Player : DbEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Grade { get; set; }

        public virtual List<PlayerStat> PlayerStats { get; set; }

        //Feels like this should be a list of TeamSeasons
        public virtual List<TeamSeasonPlayer> TeamSeasonPlayers { get; set; }
    }
}
