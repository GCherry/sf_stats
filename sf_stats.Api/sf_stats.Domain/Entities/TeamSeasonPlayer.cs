namespace sf_stats.Domain.Entities
{
    public class TeamSeasonPlayer
    {
        public int TeamSeasonId { get; set; }
        public int PlayerId { get; set; }

        public virtual TeamSeason TeamSeason { get; set; }
        public virtual Player Player { get; set; }
    }
}
