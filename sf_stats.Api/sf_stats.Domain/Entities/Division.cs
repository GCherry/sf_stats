﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Entities
{
    public class Division
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }

        public List<Game> Games { get; set; }
    }
}
