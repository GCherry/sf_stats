
namespace sf_stats.Domain.Dtos
{
    public class TeamSeasonPlayerDto : IDto
    {
        public int Id { get; set; }
        public int TeamSeasonId { get; set; }
        public int PlayerId { get; set; }
    }
}
