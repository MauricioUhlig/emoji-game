using System.ComponentModel.DataAnnotations;

namespace uhlig.game.domain.ViewModels.Game.Request
{
    public class JoinRoomRequestViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string RoomCode { get; set; }

        public JoinRoomRequestViewModel(string userName, string roomCode)
        {
            UserName = userName;
            RoomCode = roomCode;
        }
    }
}