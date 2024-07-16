using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.DataAccess.EfCore.Repositories;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern.DataAccess.EfCore.UnitOfWork
{
    public class UnitOfWorkV2 : IUnitOfWorkV2
    {
        private readonly EfRelationshipsContext _context;
        private IDbContextTransaction _transaction;
        private readonly Dictionary<Type, object> _repositories;
        public UnitOfWorkV2(EfRelationshipsContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally 
            {
                await _transaction.DisposeAsync();
                _transaction = null!;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IGenericRepositoryV2<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IGenericRepositoryV2<T>;
            }
            var respository = new GenericRepositoryV2<T>(_context);
            _repositories.Add(typeof(T), respository);
            return respository;
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
