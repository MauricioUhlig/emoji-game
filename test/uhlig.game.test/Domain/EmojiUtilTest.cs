using uhlig.game.domain.Util;

namespace uhlig.game.test.Domain;

public class EmojiUtilTest
{
    [Fact]
    public void TestGetRand()
    {
        // Arrange
        //var emojis = new Emojis();
        // Act
        var emoji = Emojis.GetRand();
        // Assert 
        Assert.NotNull(emoji);
        Assert.NotEmpty(emoji);
    }
}