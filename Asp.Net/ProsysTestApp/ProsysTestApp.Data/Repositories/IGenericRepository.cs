using System.Linq.Expressions;

namespace ProsysTestApp.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Gets();
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> expression);
    }
}
