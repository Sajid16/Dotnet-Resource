using RepositoryPattern.DataAccess.EfCore.Repositories;
using RepositoryPattern.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.EfCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfRelationshipsContext _context;
        public UnitOfWork(EfRelationshipsContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
        }
        public IBookRepository Books { get; private set; }

        //public IBookRepository Books => throw new NotImplementedException();

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
