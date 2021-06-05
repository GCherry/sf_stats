using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Dtos
{
    public class PlayerStatDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        public decimal Value { get; set; }

        public virtual StatType StatType { get; set; }
        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
    }
}
