namespace uhlig.game.domain.Entities
{
    public class RoundEntity : BaseEntity
    {
        public Guid RoomId { get; private set; }
        public string Emojis { get; private set; }
        public DateTime StartAt { get; private set; }
        public byte TotalSeconds { get; private set; }

        public virtual RoomEntity? Room { get; private set; }

        public RoundEntity(Guid roomId, string emojis, byte totalSeconds) : base()
        {
            RoomId = roomId;
            Emojis = emojis;

            StartAt = DateTime.UtcNow;
            TotalSeconds = totalSeconds;
        }

        public RoundEntity(Guid id, Guid roomId, string emojis, DateTime startAt, byte totalSeconds) : base(id)
        {
            RoomId = roomId;
            Emojis = emojis;

            StartAt = startAt;
            TotalSeconds = totalSeconds;
        }


    }
}