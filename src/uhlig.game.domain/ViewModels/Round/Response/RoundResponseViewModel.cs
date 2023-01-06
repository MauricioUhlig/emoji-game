using uhlig.game.domain.Entities;

namespace uhlig.game.domain.ViewModels.Round.Response
{
    public class RoundResponseViewModel
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; private set; }
        public string Emojis { get; private set; }
        public DateTime StartAt { get; private set; }
        public byte TotalSeconds { get; private set; }

        public RoundResponseViewModel(Guid id, Guid roomId, string emojis, DateTime startAt, byte totalSeconds)
        {
            Id = id;
            RoomId = roomId;
            Emojis = emojis;

            StartAt = startAt;
            TotalSeconds = totalSeconds;
        }
        public RoundResponseViewModel(RoundEntity round)
        {
            Id = round.Id;
            RoomId = round.RoomId;
            Emojis = round.Emojis;
            StartAt = round.StartAt;
            TotalSeconds = round.TotalSeconds;
        }
    }
}