using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.DataAccess.EfCore.Repositories;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern.DataAccess.EfCore.UnitOfWork
{
    public class UnitOfWorkV2<TContext> : IUnitOfWorkV2 where TContext : DbContext
    {
        //private readonly EfRelationshipsContext _context;
        private readonly TContext _context;
        private IDbContextTransaction _transaction;
        private readonly Dictionary<Type, object> _repositories;

        // extended repository
        public IBookRepositoryV2 BookRepository { get; }
        private readonly Dictionary<Type, object> _extendedRepositories;

        //public UnitOfWorkV2(EfRelationshipsContext context)
        public UnitOfWorkV2(TContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            _extendedRepositories = new Dictionary<Type, object>();
            // extended repository
            //BookRepository = new BookRepositoryV2(_context);
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

        // register generic repository
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

        // extended repository generic version
        public IExtendedRepository<TEntity> GetExtendedRepository<TEntity>() where TEntity : class
        {
            if (_extendedRepositories.ContainsKey(typeof(TEntity)))
            {
                return (IExtendedRepository<TEntity>)_extendedRepositories[typeof(TEntity)];
            }

            var extendedRepository = new ExtendedRepository<TEntity>(_context);
            _extendedRepositories[typeof(TEntity)] = extendedRepository;
            return extendedRepository;
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
