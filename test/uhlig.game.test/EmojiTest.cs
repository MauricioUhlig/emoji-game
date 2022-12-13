using uhlig.game.domain.Util;

namespace uhlig.game.test;

public class EmojiTest
{
    [Fact]
    public void TestGetRand()
    {
        // Arrange
        var emojis = new Emojis();
        // Act
        var emoji = emojis.GetRand();
        // Assert 
        Assert.NotNull(emoji);
        Assert.NotEmpty(emoji);
    }
}