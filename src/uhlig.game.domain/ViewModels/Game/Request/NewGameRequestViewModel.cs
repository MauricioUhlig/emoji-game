using System.ComponentModel.DataAnnotations;

namespace uhlig.game.domain.ViewModels.Game.Request
{
    public class NewGameRequestViewModel
    {
        [Required]
        public string UserName { get; set; }

        public NewGameRequestViewModel(string userName)
        {
            UserName = userName;
        }
    }
}