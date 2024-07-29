using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IUnitOfWorkV2 : IDisposable
    {
        IBookRepositoryV2 BookRepository { get; }
        IGenericRepositoryV2<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
