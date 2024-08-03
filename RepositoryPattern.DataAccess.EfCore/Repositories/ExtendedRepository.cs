using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern.DataAccess.EfCore.Repositories
{
    public class ExtendedRepository<TEntity> : GenericRepositoryV2<TEntity>, IExtendedRepository<TEntity> where TEntity : class
    {
        public ExtendedRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TEntity> FindByCondition(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}
