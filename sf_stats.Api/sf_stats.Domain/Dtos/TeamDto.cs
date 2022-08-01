using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Dtos
{
    public class TeamDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public bool IsActive { get; set; }
    }
}
