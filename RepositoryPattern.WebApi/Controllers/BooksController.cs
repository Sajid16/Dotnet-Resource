using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetPopularBooks")]
        public IActionResult GetPopularBooks()
        {
            var books = _unitOfWork.Books.GetPopularBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult GetBooks()
        {
            var books = _unitOfWork.Books.GetBooksWithRelatedInfo();
            return Ok(books);
        }
        
        [HttpGet]
        [Route("Get-Generic")]
        public IActionResult GetBooksUsingGenericMethod()
        {
            var books = _unitOfWork.Books.LoadAllWithRelatedAsync(p => p.Publisher, p => p.BookDetail, p => p.BookAuthorMaps);
            return Ok(books);
        }

        [HttpGet]
        [Route("Get-GenericV2")]
        public IActionResult GetBooksV2()
        {
            var books = _unitOfWork.Books.GetAllAsQueryable().Select(books => new {
                isbn = books.Isbn,
                id = books.BookId,
                price = books.Price,
                publisherName = books.Publisher.Name,
                authors = books.BookAuthorMaps.Select(map => map.Author.FirstName).ToList()
            }).ToList();
            return Ok(books);
        }
    }
}
