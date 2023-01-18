using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public IActionResult Create(NewGameRequestViewModel newGame)
        {
            var result = _gameService.NewGame(newGame);
            if (result == null)
                return Result();

            return Result(result);
        }

        [HttpPost("randon")]
        [AllowAnonymous]
        public IActionResult Randon(RandomRoomRequestViewModel randomRoom)
        {
            var result = _gameService.RandomGame(randomRoom);
            if (result == null)
                return Result();

            return Result(result);
        }

        [HttpPost("join")]
        [AllowAnonymous]
        public IActionResult Join(JoinRoomRequestViewModel joinRoom)
        {
            var result = _gameService.JoinGame(joinRoom);
            if (result == null)
                return Result();

            return Result(result);
        }
    }
}