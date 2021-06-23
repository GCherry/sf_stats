namespace sf_stats.Domain.Entities
{
    public class PlayerStat : DbEntity
    {
        public int TeamSeasonPlayerId { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        public decimal Value { get; set; }

        public virtual TeamSeasonPlayer TeamSeasonPlayer { get; set; }
        public virtual Game Game { get; set; }
        public virtual StatType StatType { get; set; }
    }
}
