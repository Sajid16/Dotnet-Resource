using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.EfCore.Repositories
{
    public class BookRepositoryV2 : GenericRepositoryV2<Book>, IBookRepositoryV2
    {
        public BookRepositoryV2(EfRelationshipsContext efRelationshipsContext) : base(efRelationshipsContext)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByNames(string name)
        {
            return await _dbSet.Where(book => book.Title.Contains(name)).ToListAsync();
        }
    }
}
