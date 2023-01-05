using Microsoft.AspNetCore.Mvc;
using uhlig.game.domain.ViewModels.Round.Request;

namespace uhlig.game.api.Controllers
{
    public class RoundController : ApiController
    {
        public RoundController()
        {

        }

        [HttpGet]
        public IActionResult GetLastRoundByRoomId([FromQuery] Guid roomId)
        {
            return Result("Nova Sala Criada Com Sucesso!!");
        }

        [HttpGet("new")]
        public IActionResult CreateNewRoundByRoomId([FromQuery] Guid roomId)
        {
            return Result("Nova Sala Criada Com Sucesso!!");
        }

        [HttpGet("all")]
        public IActionResult GetAllRoundsByRoomId([FromQuery] Guid roomId)
        {
            return Result("Nova Sala Criada Com Sucesso!!");
        }
        [HttpGet("{id:guid}/result")]
        public IActionResult RoundResult(Guid id)
        {
            return Result("Sala aleatória");
        }

        [HttpPost("{id:guid}/submit")]
        public IActionResult Join(NewPhraseRequestViewModel joinRoom)
        {
            return Result("Entrou na sala");
        }
    }
}