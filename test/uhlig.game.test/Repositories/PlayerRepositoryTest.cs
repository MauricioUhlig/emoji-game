using uhlig.game.domain.Interfaces.Repositories;
using uhlig.game.domain.Entities;

namespace uhlig.game.test.Repositories;

public class PlayerRepositoryTes
{
    private readonly IBaseRepository<PlayerEntity> _repository;
    public PlayerRepositoryTes(IBaseRepository<PlayerEntity> repository)
    {
        _repository = repository;
    }

    [Fact]
    public void TestInsert()
    {
        // Arrange
        var player = new PlayerEntity("Mauricio");

        // Act
        _repository.Insert(player);

        var inserted = _repository.GetById(player.Id);
        // Assert 
        Assert.NotNull(inserted);
        Assert.Equal(player, inserted);
    }

    [Fact]
    public void TestSelectById()
    {
        //Arrange
        Guid id = Guid.Parse("bfce80db-3143-4594-91f2-7e1a74fa3b19");

        //Act
        var player = _repository.GetById(id);

        //Assert
        Assert.NotNull(player);
        Assert.Equal(id, player.Id);
    }

    [Fact]
    public void TestSelectAll()
    {
        //Arrange

        //Act
        var rounds = _repository.GetAll();

        //Assert
        Assert.NotNull(rounds);
        Assert.Single(rounds);
    }

    [Fact]
    public void TestPlayerScoreUpdate()
    {
        //Arrange
        Guid id = Guid.Parse("bfce80db-3143-4594-91f2-7e1a74fa3b19");
        var player = _repository.GetById(id);
        if (player == null)
            throw new ArgumentNullException("Player não encontrado!");

        //Act
        player.AddScore(1);
        _repository.Update(player);
        var _player = _repository.GetById(id);

        //Assert
        Assert.Equal(551, _player?.Score);
        Assert.Equivalent(player, _player);
    }
}