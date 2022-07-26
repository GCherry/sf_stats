using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.DomainObjects
{
    public class GameQueryFilter
    {
        public int? Id { get; set; }
        public DateTime? GameDate { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }
    }
}
