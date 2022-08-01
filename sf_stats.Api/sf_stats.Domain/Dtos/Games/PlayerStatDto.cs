

namespace sf_stats.Domain.Dtos
{
    public class PlayerStatDto : IDto
    {
        public int Id { get; set; }
        public int TeamSeasonPlayerId { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        public decimal Value { get; set; }
    }
}
