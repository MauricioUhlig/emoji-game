namespace uhlig.game.domain.Entities
{
    public class RoundEntity
    {
        public Guid Id { get; private set; }
        public Guid RoomId { get; private set; }
        public IEnumerable<Guid> PlayersId { get; private set; }
        public string Emojis { get; private set; }
        public DateTime StartAt { get; private set; }
        public byte TotalSeconds { get; private set; }

        public RoundEntity(Guid roomId, IEnumerable<Guid> playersId, string emojis, byte totalSeconds)
        {
            Id = Guid.NewGuid();

            RoomId = roomId;
            PlayersId = playersId;
            Emojis = emojis;

            StartAt = DateTime.UtcNow;
            TotalSeconds = totalSeconds;
        }

        public void AddNewPlayer(Guid playerId) => PlayersId.Append(playerId);
        public void RemoverPlayer(Guid playerId) => PlayersId = PlayersId.Where(x => x != playerId);
    }
}