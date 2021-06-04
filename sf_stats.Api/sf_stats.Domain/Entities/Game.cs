using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sf_stats.Domain.Entities
{
    public class Game
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
