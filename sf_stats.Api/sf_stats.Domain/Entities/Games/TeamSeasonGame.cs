using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Entities
{
    public class TeamSeasonGame : DbEntity
    {
        public int GameId { get; set; }
        public int TeamSeasonId { get; set; }
        public bool IsHomeTeam { get; set; }

        
        public Game Game { get; set; }
        public TeamSeason TeamSeason { get; set; }
    }
}