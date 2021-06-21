using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Division : DbEntity
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }

        public virtual List<Season> Seasons { get; set; }
    }
}
