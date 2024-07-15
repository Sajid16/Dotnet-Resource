using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.EfCore.Repositories
{
    public class GenericRepositoryV2<TEntity> : IGenericRepositoryV2<TEntity> where TEntity : class
    {
        private readonly EfRelationshipsContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepositoryV2(EfRelationshipsContext efRelationshipsContext)
        {
            _dbSet = efRelationshipsContext.Set<TEntity>();
            _context = efRelationshipsContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> GetQuerable()
        {
            return _dbSet.AsQueryable();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
