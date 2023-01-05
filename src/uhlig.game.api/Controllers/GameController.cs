using Microsoft.AspNetCore.Mvc;
using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Game.Request;

namespace uhlig.game.api.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("new")]
        public IActionResult Create(NewGameRequestViewModel newGame)
        {
            return Result(_gameService.NewGame(newGame));
        }

        [HttpPost("randon")]
        public IActionResult Randon(RandomRoomRequestViewModel randomRoom)
        {
            return Result(_gameService.RandomGame(randomRoom));
        }

        [HttpPost("join")]
        public IActionResult Join(JoinRoomRequestViewModel joinRoom)
        {
            return Result(_gameService.JoinGame(joinRoom));
        }
    }
}