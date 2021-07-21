using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.DomainObjects
{
    public class DivisionQueryFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}