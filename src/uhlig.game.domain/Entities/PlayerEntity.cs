namespace uhlig.game.domain.Entities
{
    public class PlayerEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Score { get; private set; }

        public PlayerEntity(string name)
        {
            Id = Guid.NewGuid();

            Name = name;

            Score = 0;
        }

        public void SetScore(int score) => Score = score;
    }
}