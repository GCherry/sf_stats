using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.DomainObjects
{
    public class PlayerStatQueryFilter
    {
        public int? TeamSeasonPlayerId { get; set; }
        public int? GameId { get; set; }
        public int? StatTypeId { get; set; }
        public decimal? Value { get; set; }
    }
}
