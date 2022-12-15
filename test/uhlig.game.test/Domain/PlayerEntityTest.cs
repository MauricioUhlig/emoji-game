using uhlig.game.domain.Entities;

namespace uhlig.game.test.Domain;
public class PlayerEntityTest
{
    [Fact]
    public void TestNewPlayer()
    {
        // Arrange
        var playerName = "Harry Styles";
    
        var player = new PlayerEntity(playerName);
        // Act

        // Assert 
        Assert.NotNull(player);
        Assert.Equal(playerName, player.Name);
        Assert.Equal(0, player.Score);
        Assert.IsType<Guid>(player.Id);
    }

    [Fact]
    public void TestChangePlayerScore()
    {
        // Arrange
        var playerName = "Harry Styles";
        var score = 50;
        var player = new PlayerEntity(playerName);
        // Act
        player.SetScore(score);
        
        // Assert 
        Assert.Equal(score, player.Score);
    }
}