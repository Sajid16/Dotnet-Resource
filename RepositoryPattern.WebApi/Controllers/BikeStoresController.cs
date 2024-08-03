using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeStoresController : ControllerBase
    {
        private readonly IUnitOfWorkV2 _unitOfWorkV2;

        public BikeStoresController(IUnitOfWorkV2 unitOfWorkV2)
        {
            _unitOfWorkV2 = unitOfWorkV2;
        }

        //[HttpGet]
        //[Route("Get-All-Customers")]
        //public async Task<IActionResult> Get()
        //{
        //    var response = await _unitOfWorkV2.GetRepository<Customer>().GetQuerable().ToListAsync();
        //    return Ok(response);
        //}
    }
}
