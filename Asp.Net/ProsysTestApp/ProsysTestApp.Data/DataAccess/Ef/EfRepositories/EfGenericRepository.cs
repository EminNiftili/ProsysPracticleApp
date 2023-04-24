using Microsoft.EntityFrameworkCore;
using ProsysTestApp.Data.Entities;
using ProsysTestApp.Data.Repositories;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ProsysTestApp.Data.DataAccess.Ef.EfRepositories
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public EfGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<TEntity> Gets()
        {
            return _dbSet.AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }
    }
}
