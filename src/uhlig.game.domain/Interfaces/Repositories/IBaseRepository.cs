using uhlig.game.domain.Entities;
using System.Linq.Expressions;
namespace uhlig.game.domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid id);
        T? GetById(Guid id);
        IEnumerable<T>? GetAll();
        IEnumerable<T>? GetByExpression(Expression<Func<BaseEntity, bool>> predicate);
    }
}