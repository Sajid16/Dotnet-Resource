using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IBookRepositoryV2 : IGenericRepositoryV2<Book>
    {
        Task<IEnumerable<Book>> GetBooksByNames(string name);
    }
}
