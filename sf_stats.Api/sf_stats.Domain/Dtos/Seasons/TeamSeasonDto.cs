
namespace sf_stats.Domain.Dtos
{
    public class TeamSeasonDto : IDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int SeasonId { get; set; }
    }
}
