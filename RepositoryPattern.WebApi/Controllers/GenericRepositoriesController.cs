using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.ViewModels;

namespace RepositoryPattern.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericRepositoriesController : ControllerBase
    {
        private readonly IGenericRepositoryV2<Book> genericRepositoryV2;
        private readonly IGenericRepositoryV2<BookAuthorMap> bookAuthorgenericRepositoryV2;

        public GenericRepositoriesController(IGenericRepositoryV2<Book> genericRepositoryV2, IGenericRepositoryV2<BookAuthorMap> bookAuthorgenericRepositoryV2)
        {
            this.genericRepositoryV2 = genericRepositoryV2;
            this.bookAuthorgenericRepositoryV2 = bookAuthorgenericRepositoryV2;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookVm bookVm)
        {
            Book book = new Book()
            {
                Title = bookVm.Title,
                Isbn = bookVm.ISBN,
                Price = bookVm.Price,
                PublisherId = bookVm.publisherId
            };
            await genericRepositoryV2.AddAsync(book);
            await genericRepositoryV2.SaveChanges();

            List<BookAuthorMap> bookAuthorMaps = new List<BookAuthorMap>();
            foreach (var author in bookVm.authorIds)
            {
                BookAuthorMap bookAuthorMap = new BookAuthorMap()
                {
                    AuthorId = author,
                    BookId = book.BookId
                };

                bookAuthorMaps.Add(bookAuthorMap);
            }
            await bookAuthorgenericRepositoryV2.AddRangeAsync(bookAuthorMaps);
            await bookAuthorgenericRepositoryV2.SaveChanges();

            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await genericRepositoryV2.GetQuerable().Select(book => new BookUIVm()
            {
                Id = book.BookId,
                ISBN = book.Isbn,
                Price = book.Price,
                Title = book.Title,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.BookAuthorMaps.Select(authors => authors.Author.FirstName).ToList(),
                //details = new BookDetailUiVM()
                //{
                //    Weight = book.BookDetail.Weight,
                //    Pages = book.BookDetail.Pages,
                //    Chapters = book.BookDetail.Chapters
                //}
            }).ToListAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await genericRepositoryV2.GetQuerable().Where(book => book.BookId == id).Select(book => new BookUIVm()
            {
                ISBN = book.Isbn,
                Price = book.Price,
                Title = book.Title,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.BookAuthorMaps.Select(authors => authors.Author.FirstName).ToList(),
                details = new BookDetailUiVM()
                {
                    Weight = book.BookDetail.Weight,
                    Pages = book.BookDetail.Pages,
                    Chapters = book.BookDetail.Chapters
                }
            }).FirstOrDefaultAsync();
            return Ok(books);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BookVmUpdate bookVmUpdate)
        {
            var book = await genericRepositoryV2.GetByIdAsync(bookVmUpdate.Id);
            if(book is null) return NotFound();

            book.Title = bookVmUpdate.Title;
            book.Price = bookVmUpdate.Price;
            await genericRepositoryV2.UpdateAsync(book);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await genericRepositoryV2.GetByIdAsync(id);
            if (book is null) return NotFound();

            await genericRepositoryV2.RemoveAsync(book);
            await genericRepositoryV2.SaveChanges();
            return Ok("Deleted");
        }
    }
}
