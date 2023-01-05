namespace uhlig.game.domain.ViewModels.Game.Response
{
    public class NewGameResponseViewModel
    {
        public Guid RoomId { get; set; }
        public Guid PlayerId { get; set; }
        public string RoomCode { get; set; }

        public NewGameResponseViewModel(Guid roomId, Guid playerId, string roomCode)
        {
            RoomId = RoomId;
            PlayerId = playerId;
            RoomCode = roomCode;
        }
    }
}