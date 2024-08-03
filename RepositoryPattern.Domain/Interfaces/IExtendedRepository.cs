using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IExtendedRepository<TEntity> : IGenericRepositoryV2<TEntity> where TEntity : class
    {
        // Add extended methods here
        IEnumerable<TEntity> FindByCondition(Func<TEntity, bool> predicate);
    }
}
