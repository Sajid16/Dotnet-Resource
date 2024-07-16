using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DataAccess.EfCore.Repositories;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.ViewModels;

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
                //details = new BookDetailUiVM()
                //{
                //    Weight = book.BookDetail.Weight,
                //    Pages = book.BookDetail.Pages,
                //    Chapters = book.BookDetail.Chapters
                //}
            }).ToListAsync();
            return Ok(books);
        }
    }
}
