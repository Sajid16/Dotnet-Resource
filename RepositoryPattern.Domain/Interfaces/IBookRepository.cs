using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetPopularBooks();
        IEnumerable<BookUIVm> GetBooksWithRelatedInfo();
    }
}
