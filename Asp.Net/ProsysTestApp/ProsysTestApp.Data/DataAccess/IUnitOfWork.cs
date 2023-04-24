using ProsysTestApp.Data.Repositories;

namespace ProsysTestApp.Data.DataAccess
{
    public interface IUnitOfWork
    {
        void Commit();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
