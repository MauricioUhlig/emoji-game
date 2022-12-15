using System.ComponentModel.DataAnnotations;

namespace uhlig.game.domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}