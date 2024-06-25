using RepositoryPattern.DataAccess.EfCore.UnitOfWork;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.EfCore.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(EfRelationshipsContext context) : base(context)
        {
        }

        IEnumerable<Book> IBookRepository.GetPopularBooks()
        {
            return _context.Books.OrderByDescending(d => d.BookId).ToList();
        }

        IEnumerable<BookUIVm> IBookRepository.GetBooksWithRelatedInfo()
        {
            var books = _context.Books.Select(books => new BookUIVm()
            {
                ISBN = books.Isbn,
                Price = books.Price,
                Title = books.Title,
                PublisherName = books.Publisher.Name,
                AuthorNames = books.BookAuthorMaps.Select(authors => authors.Author.FirstName).ToList(),
                details = new BookDetailUiVM()
                {
                    Weight = books.BookDetail.Weight,
                    Pages = books.BookDetail.Pages,
                    Chapters = books.BookDetail.Chapters
                }
            }).ToList();

            return books;
        }
    }
}
