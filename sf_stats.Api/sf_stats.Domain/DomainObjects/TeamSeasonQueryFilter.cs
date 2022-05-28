using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.DomainObjects
{
    public class TeamSeasonQueryFilter
    {
        public int? Id { get; set; }
        public int? TeamId { get; set; }
        public int? SeasonId { get; set; }
    }
}
