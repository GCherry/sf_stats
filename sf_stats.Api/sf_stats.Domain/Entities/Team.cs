using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Team : DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public bool IsActive { get; set; }

        public virtual List<TeamSeason> TeamSeasons { get; set; }
    }
}
