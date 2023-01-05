using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Game.Request;

namespace uhlig.game.test.Service;

public class GameServiceTest
{
    private readonly IGameService _gameService;
    public GameServiceTest(IGameService gameService)
    {
        _gameService = gameService;
    }
    [Fact]
    public void TestNewGame()
    {
        // Arrange
        var room = new NewGameRequestViewModel("Mauricio");
        // Act
        var game = _gameService.NewGame(room);
        // Assert 
        Assert.NotNull(game);
        
    }
    [Fact]
    public void TestJoinGame()
    {
        // Arrange
        var room = new JoinRoomRequestViewModel("Mauricio", "teste");
        // Act
        var game = _gameService.JoinGame(room);
        // Assert 
        Assert.NotNull(game);
        
    }
    [Fact]
    public void TestRandomGame()
    {
        // Arrange
        var room = new RandomRoomRequestViewModel("Mauricio");
        // Act
        var game = _gameService.RandomGame(room);
        // Assert 
        Assert.NotNull(game);
        
    }
}