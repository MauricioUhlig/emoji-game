using uhlig.game.domain.ViewModels.Game.Request;
using uhlig.game.domain.ViewModels.Game.Response;

namespace uhlig.game.domain.Interfaces.Services
{
    public interface IGameService
    {
        public NewGameResponseViewModel NewGame(NewGameRequestViewModel newRoom);
        public NewGameResponseViewModel JoinGame(JoinRoomRequestViewModel joinRoom);
        public NewGameResponseViewModel RandomGame(RandomRoomRequestViewModel randomRoom);
    }
}