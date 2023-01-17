using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.Notifications;
using uhlig.game.domain.ViewModels.Round.Request;

namespace uhlig.game.test.Service;

public class RoundServiceTest
{
    private readonly IRoundService _roundService;
    private readonly DomainNotification _domainNotification;
    public RoundServiceTest(IRoundService roundService, DomainNotification domainNotification)
    {
        _roundService = roundService;
        _domainNotification = domainNotification;
    }
    [Fact]
    public void TestNewRound()
    {
        // Arrange
        var roomId = new Guid("b5212d38-9600-47c6-a5ab-8a7e7d2b3421");
        // Act
        var round = _roundService.CreateNewRoundByRoomId(roomId);
        // Assert 
        Assert.NotNull(round);
    }
    [Theory]
    [InlineData("b5212d38-9600-47c6-a5ab-8a7e7d2b3421", true)]
    [InlineData("b5212d38-9600-47c6-0000-8a7e7d2b3421", false)]
    public void TestGetLastRoundByRoomId(Guid id, bool exists)
    {
        // Arrange
        var round = _roundService.GetLastRoundByRoomId(id);

        // Act
        if (exists)
        {
            // Assert 
            Assert.NotNull(round);
            Assert.NotEmpty(round.Emojis);
            Assert.True(_domainNotification.IsValid());
        }
        else
        {
            Assert.Null(round);
            Assert.False(_domainNotification.IsValid());
        }
    }
    [Fact]
    public void TestGetAllRoundsByRoomId()
    {
        // Arrange
        var roomId = new Guid("b5212d38-9600-47c6-a5ab-8a7e7d2b3421");
        // Act
        var round = _roundService.GetAllRoundsByRoomId(roomId);
        // Assert 
        Assert.NotNull(round);
        Assert.Single(round);

    }
    [Theory]
    [InlineData("10de598e-5bfd-4c6c-95d7-a64c83a5fdf1", "bfce80db-3143-4594-91f2-7e1a74fa3b19", "Frase de teste", true)]
    [InlineData("00000000-9600-47c6-a5ab-8a7e7d2b3421", "bfce80db-3143-4594-91f2-7e1a74fa3b19", "Frase de teste", false)]
    public void TestSubmit(Guid roundId, Guid playerId, string phrase, bool success)
    {
        // Arrange
        var submit = new NewPhraseRequestViewModel(roundId, playerId, phrase);
        // Act
        var roundPhrase = _roundService.Submit(submit);
        // Assert 
        Assert.NotNull(roundPhrase);
        Assert.Equal(success, roundPhrase.Success);

    }
    [Fact]
    public void TestRoundResult()
    {
        // Arrange
        var roundId = new Guid("10de598e-5bfd-4c6c-95d7-a64c83a5fdf1");
        // Act
        var round = _roundService.RoundResult(roundId);
        // Assert 
        Assert.NotNull(round);

    }
    [Fact]
    public void TestRoundPhrases()
    {
        // Arrange
        var roundId = new Guid("10de598e-5bfd-4c6c-95d7-a64c83a5fdf1");
        // Act
        var round = _roundService.RoundPhrases(roundId);
        // Assert 
        Assert.NotNull(round);
    }
    [Fact]
    public void TestVote()
    {
        // Arrange
        var roundPhraseId = new Guid("9031e8c3-9452-4087-8189-fb380a7f255a");
        var voterId = new Guid("bfce80db-3143-4594-91f2-7e1a74fa3b19");
        // Act
        var success = _roundService.Vote(voterId, roundPhraseId);
        // Assert 
        Assert.True(success);
    }

}