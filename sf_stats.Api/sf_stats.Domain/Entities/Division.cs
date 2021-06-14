﻿using System.Collections.Generic;

namespace sf_stats.Domain.Entities
{
    public class Division : DbEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
