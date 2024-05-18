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
    public class AuthorsController : ControllerBase
    {
        private readonly RelatonshipsContext _context;

        public AuthorsController(RelatonshipsContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("add-author")]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            //Author _author = new Author()
            //{
            //    BirthDate = author.BirthDate,
            //    FirstName = author.FirstName,
            //    LastName = author.LastName,
            //    Location = author.Location,
            //};
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            var test = author.Author_Id.ToString();
            return Created(String.Empty, author);
        }

        [HttpPost]
        [Route("add-fluent-author")]
        public async Task<IActionResult> AddFluentAuthor(AuthorVM author)
        {
            Fluent_Author _author = new Fluent_Author()
            {
                FirstName = author.FirstName,
                Location = author.Location,
                LastName = author.LastName,
                BirthDate = author.BirthDate,
            };
            await _context.Fluent_Authors.AddAsync(_author);
            await _context.SaveChangesAsync();

            var test = _author.Author_Id.ToString();
            return Created(String.Empty, _author);
        }

        [HttpDelete]
        [Route("delete-authors")]
        public async Task<IActionResult> DeleteBook([Required] int AuthorId)
        {
            var _author = await _context.Authors.Where(book => book.Author_Id == AuthorId).FirstOrDefaultAsync();
            if (_author is not null)
            {
                _context.Authors.Remove(_author);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
