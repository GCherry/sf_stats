using System;
using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Season : DbEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<TeamSeason> TeamSeasons { get; set; }
    }
}
