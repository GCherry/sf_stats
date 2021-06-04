using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }

        [ForeignKey("Season")]
        public int SeasonId { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        [ForeignKey("Team")]
        public int Home_TeamId { get; set; }

        [ForeignKey("Team")]
        public int Away_TeamId { get; set; }

        public virtual Season Season { get; set; }
        public virtual Division Division { get; set; }
        public virtual Team Home_Team { get; set; }
        public virtual Team Away_Team { get; set; }
    }
}
