namespace uhlig.game.domain.ViewModels.Game.Response
{
    public class NewGameResponseViewModel
    {
        public Guid RoomId { get; set; }
        public Guid PlayerId { get; set; }
        public string RoomCode { get; set; }
        public string Token { get; set; }

        public NewGameResponseViewModel(Guid roomId, Guid playerId, string roomCode, string token)
        {
            RoomId = roomId;
            PlayerId = playerId;
            RoomCode = roomCode;
            Token = token;
        }
    }
}