using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DataAccess.EfCore.Repositories;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.ViewModels;
using System.Net;

namespace RepositoryPattern.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfWorksController : ControllerBase
    {
        private readonly IUnitOfWorkV2 _unitOfWorkV2;
        public UnitOfWorksController(IUnitOfWorkV2 unitOfWorkV2)
        {
            _unitOfWorkV2 = unitOfWorkV2;
        }

        [HttpGet]
        [Route("get-all-books")]
        public async Task<IActionResult> Get()
        {
            var query = _unitOfWorkV2.GetRepository<Book>().GetQuerable();
            var books = await query.Select(book => new BookUIVm()
            {
                Id = book.BookId,
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
            }).ToListAsync();
            return Ok(books);
        }

        [HttpPost]
        [Route("add-book")]
        public async Task<IActionResult> Post(BookVm bookVm)
        {
            try
            {
                Book bookEntity = new Book
                {
                    Isbn = bookVm.ISBN,
                    Price = bookVm.Price,
                    Title = bookVm.Title,
                    PublisherId = bookVm.publisherId,
                };
                using var transaction = _unitOfWorkV2.BeginTransactionAsync();
                await _unitOfWorkV2.GetRepository<Book>().AddAsync(bookEntity);
                await _unitOfWorkV2.SaveChangesAsync();

                BookDetail bookDetail = new BookDetail
                {
                    BookId = bookEntity.BookId,
                    Chapters = bookVm.Details.Chapters,
                    Pages = bookVm.Details.Pages,
                    Weight = bookVm.Details.Weight
                };
                await _unitOfWorkV2.GetRepository<BookDetail>().AddAsync(bookDetail);
                await _unitOfWorkV2.SaveChangesAsync();

                List<BookAuthorMap> bookAuthorMaps = new List<BookAuthorMap>();
                foreach (var bookAuthor in bookVm.authorIds)
                {
                    BookAuthorMap bookAuthorMap = new BookAuthorMap
                    {
                        BookId = bookEntity.BookId,
                        AuthorId = bookAuthor
                    };
                    bookAuthorMaps.Add(bookAuthorMap);
                }
                await _unitOfWorkV2.GetRepository<BookAuthorMap>().AddRangeAsync(bookAuthorMaps);
                await _unitOfWorkV2.SaveChangesAsync();

                await _unitOfWorkV2.CommitAsync();

                return Created();
            }
            catch (Exception ex)
            {
                await _unitOfWorkV2.RollbackAsync();
                throw;
            }
        }

        [HttpGet]
        [Route("get-by-title")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var response = await _unitOfWorkV2.BookRepository.GetBooksByNames(title);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-from-extendedRepo")]
        public IActionResult GetInfo(string title)
        {
            var response = _unitOfWorkV2.GetExtendedRepository<Book>().FindByCondition(book=> book.Title.Contains(title));
            return Ok(response);
        }

    }
}
