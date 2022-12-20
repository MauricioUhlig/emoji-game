namespace uhlig.game.domain.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public PlayerEntity(string name) : base()
        {
            Name = name;

            Score = 0;
        }
          public PlayerEntity(Guid id, string name, int score) : base(id)
        {
            Name = name;
            Score = score;
        }

        public void SetScore(int score) => Score = score;
    }
}