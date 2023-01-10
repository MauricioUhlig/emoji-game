using Microsoft.AspNetCore.Mvc;
using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.Notifications;
using uhlig.game.domain.ViewModels.Game.Request;

namespace uhlig.game.api.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService, DomainNotification domainNotification) : base(domainNotification)
        {
            _gameService = gameService;
        }

        [HttpPost("new")]
        public IActionResult Create(NewGameRequestViewModel newGame)
        {
            var result = _gameService.NewGame(newGame);
            if (result == null)
                return Result();

            return Result(result);
        }

        [HttpPost("randon")]
        public IActionResult Randon(RandomRoomRequestViewModel randomRoom)
        {
            var result = _gameService.RandomGame(randomRoom);
            if (result == null)
                return Result();

            return Result(result);
        }

        [HttpPost("join")]
        public IActionResult Join(JoinRoomRequestViewModel joinRoom)
        {
            var result = _gameService.JoinGame(joinRoom);
            if (result == null)
                return Result();

            return Result(result);
        }
    }
}