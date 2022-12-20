using uhlig.game.domain.Interfaces.Repositories;
using uhlig.game.domain.Entities;

namespace uhlig.game.test.Repositories;

public class BaseRepositoryTest
{
    private readonly IBaseRepository<RoundEntity> _repository;
    public BaseRepositoryTest(IBaseRepository<RoundEntity> repository)
    {
        _repository = repository;
    }

    [Fact]
    public void TestInsert()
    {
        // Arrange
        var player = new PlayerEntity("Mauricio");
        var room = new RoomEntity(true, 4);

        var playerList = new List<Guid>();
        playerList.Add(player.Id);
        var round = new RoundEntity(room.Id, "emojis", 60);

        // Act
        _repository.Insert(round);

        var inserted = _repository.GetById(round.Id);
        // Assert 
        Assert.NotNull(inserted);
        Assert.Equal(round, inserted);
    }

    [Fact]
    public void TestSelectById()
    {
        //Arrange
        Guid id = Guid.Parse("10de598e-5bfd-4c6c-95d7-a64c83a5fdf1");

        //Act
        var round = _repository.GetById(id);

        //Assert
        Assert.NotNull(round);
        Assert.Equal(id, round.Id);
    }

    [Fact]
    public void TestSelectAll()
    {
        //Arrange

        //Act
        var rounds = _repository.GetAll();

        //Assert
        Assert.NotNull(rounds);
        Assert.Equal(1, rounds.Count());
    }
}