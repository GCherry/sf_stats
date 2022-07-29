namespace sf_stats.Domain.Dtos
{
    public class TeamSeasonGameDto : IDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int TeamSeasonId { get; set; }
        public bool IsHomeTeam { get; set; }
    }
}
