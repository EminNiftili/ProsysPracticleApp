using Microsoft.EntityFrameworkCore;
using ProsysTestApp.Data.DataAccess.Ef.EfRepositories;
using ProsysTestApp.Data.Repositories;

namespace ProsysTestApp.Data.DataAccess.Ef
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbConext;

        public EfUnitOfWork()
        {
            _dbConext = new ProsysDbContext();
        }

        public void Commit()
        {
            _dbConext.SaveChanges();
        }


        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repository = new EfGenericRepository<TEntity>(_dbConext);

            return repository;
        }
    }
}
