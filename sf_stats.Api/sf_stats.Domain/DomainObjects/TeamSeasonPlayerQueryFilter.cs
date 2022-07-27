using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.DomainObjects
{
    public class TeamSeasonPlayerQueryFilter
    {
        public int? Id { get; set; }
        public int? PlayerId { get; set; }
        public int? TeamSeasonId { get; set; }
    }
}
