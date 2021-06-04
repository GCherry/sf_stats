using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public bool IsActive { get; set; }

        public virtual List<Game> HomeGames { get; set; }
        public virtual List<Game> AwayGames { get; set; }
    }
}
