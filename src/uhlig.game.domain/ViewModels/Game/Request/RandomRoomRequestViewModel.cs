using System.ComponentModel.DataAnnotations;

namespace uhlig.game.domain.ViewModels.Game.Request
{
    public class RandomRoomRequestViewModel
    {
        [Required]
        public string UserName { get; set; }

        public RandomRoomRequestViewModel(string userName)
        {
            UserName = userName;
        }
    }
}