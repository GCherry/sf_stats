﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Dtos
{
    public class DivisionDto : IDto
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }
}
