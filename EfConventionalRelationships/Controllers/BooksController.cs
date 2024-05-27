using EfConventionalRelationships.Data;
using EfConventionalRelationships.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EfConventionalRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RelatonshipsContext _dbContext;

        public BooksController(RelatonshipsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("add-book")]
        public async Task<IActionResult> AddBook(BookVm bookVm)
        {
            Book book = new Book()
            {
                Title = bookVm.Title,
                ISBN = bookVm.ISBN,
                Price = bookVm.Price,
                Publisher_Id = bookVm.publisherId
            };
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            List<BookAuthorMap> bookAuthorMaps = new List<BookAuthorMap>();
            foreach (var item in bookVm.authorIds)
            {
                BookAuthorMap bookAuthorMap = new BookAuthorMap()
                {
                    Author_Id = item,
                    Book_Id = book.BookId
                };
                bookAuthorMaps.Add(bookAuthorMap);
            }

            await _dbContext.AddRangeAsync(bookAuthorMaps);
            await _dbContext.SaveChangesAsync();
            return Created(string.Empty, book);
        }

        [HttpGet]
        [Route("get-book")]
        public async Task<IActionResult> GetBook()
        {
            //var result = await _dbContext.Books.Include(u => u.Publisher).Include(u => u.bookAuthorMaps).ToListAsync();
            var result = await _dbContext.Books.Select(books => new BookUIVm()
            {
                ISBN = books.ISBN,
                Price = books.Price,
                Title = books.Title,
                PublisherName = books.Publisher.Name,
                AuthorNames = books.bookAuthorMaps.Select(authors => authors.Author.FirstName).ToList()
            }).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("get-book-with-details")]
        public async Task<IActionResult> GetBookWithDetails()
        {
            //var result = await _dbContext.Books.Include(u => u.Publisher).Include(u => u.bookAuthorMaps).ToListAsync();
            //var result1 = await _dbContext.Books.Include(u => u.Publisher).Include(u => u.bookAuthorMaps).Include(u => u.BookDetail).ToListAsync();
            var result = await _dbContext.Books.Select(books => new BookUIVm()
            {
                ISBN = books.ISBN,
                Price = books.Price,
                Title = books.Title,
                PublisherName = books.Publisher.Name,
                AuthorNames = books.bookAuthorMaps.Select(authors => authors.Author.FirstName).ToList(),
                details = new BookDetailUiVM()
                {
                    Weight = books.BookDetail.Weight,
                    Pages = books.BookDetail.Pages,
                    Chapters = books.BookDetail.Chapters
                }

            }).ToListAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-book")]
        public async Task<IActionResult> DeleteBook([Required] int BookId)
        {
            var _book = await _dbContext.Books.Where(book => book.BookId == BookId).FirstOrDefaultAsync();
            if (_book is not null)
            {
                _dbContext.Books.Remove(_book);
                await _dbContext.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
