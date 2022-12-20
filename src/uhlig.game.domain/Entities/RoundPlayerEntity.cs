namespace uhlig.game.domain.Entities
{
    public class RoundPlayerEntity : BaseEntity
    {
        public Guid RoundId { get; private set; }
        public Guid PlayerId { get; private set; }

        public RoundEntity? Round { get; set; }
        public PlayerEntity? Player { get; set; }

        public RoundPlayerEntity(Guid roundId, Guid playerId) : base()
        {
            RoundId = roundId;
            PlayerId = playerId;
        }

        public RoundPlayerEntity(Guid id, Guid roundId, Guid playerId) : base(id)
        {
            RoundId = roundId;
            PlayerId = playerId;
        }
    }
}