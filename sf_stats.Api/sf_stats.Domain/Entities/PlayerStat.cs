namespace sf_stats.Domain.Entities
{
    public class PlayerStat : DbEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        // Unsure what the ideal value here is
        public decimal Value { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
        public virtual StatType StatType { get; set; }
    }
}
