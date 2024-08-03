namespace RepositoryPattern.Domain.Interfaces
{
    public interface IUnitOfWorkV2 : IDisposable
    {
        IBookRepositoryV2 BookRepository { get; }
        IExtendedRepository<T> GetExtendedRepository<T>() where T : class;
        IGenericRepositoryV2<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
