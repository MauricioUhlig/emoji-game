using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.Notifications;
using uhlig.game.domain.ViewModels.Game.Request;

namespace uhlig.game.test.Service;

public class GameServiceTest
{
    private readonly IGameService _gameService;
    private readonly DomainNotification _domainNotification;
    public GameServiceTest(IGameService gameService, DomainNotification domainNotification)
    {
        _gameService = gameService;
        _domainNotification = domainNotification;
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
    [Theory]
    [InlineData("Mauricio", "code", true)]
    [InlineData("Mauricio", "c404", false)]
    public void TestJoinGame(string name, string code, bool exists)
    {
        // Arrange
        var room = new JoinRoomRequestViewModel(name, code);
        // Act
        var game = _gameService.JoinGame(room);
        // Assert 
        if (exists)
        {
            Assert.NotNull(game);
            Assert.True(_domainNotification.IsValid());
        }
        else
        {
            Assert.Null(game);
            Assert.False(_domainNotification.IsValid());
        }
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