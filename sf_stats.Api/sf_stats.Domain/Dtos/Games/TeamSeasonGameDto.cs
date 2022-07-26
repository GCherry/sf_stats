namespace sf_stats.Domain.Dtos.Games
{
    public class TeamSeasonGameDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int TeamSeasonId { get; set; }
        public bool IsHomeTeam { get; set; }
    }
}
