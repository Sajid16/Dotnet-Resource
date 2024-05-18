using EfConventionalRelationships.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfConventionalRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfRelationshipsController : ControllerBase
    {
        private readonly RelatonshipsContext _relatonshipsContext;
        public EfRelationshipsController(RelatonshipsContext relatonshipsContext)
        {
            _relatonshipsContext = relatonshipsContext;
        }

        [HttpGet]
        [Route("one-to-one")]
        public async Task<IActionResult> OneToOne()
        {
            var response = await _relatonshipsContext.Students
                //.Include(s => s.Grade)
                .ToListAsync();

            var response2 = await _relatonshipsContext.Grades
                //.Include(s => s.Students)
                .ToListAsync();

            //var grade = response.
            //var course = await _relatonshipsContext.Students
            //    .Include(i => i.Grade)
            //    .ToListAsync();
            //var response = await _relatonshipsContext.Students.FirstOrDefaultAsync();
            return Ok(response2);
        }

        [HttpPost]
        [Route("one-to-one")]
        public async Task<IActionResult> OneToOnePost()
        {
            Student std1 = new Student();
            std1.Name = "test1";
            
            Grade grd = new Grade();
            grd.GradeName = "T1";
            std1.Grade = grd;

            _relatonshipsContext.Add(std1);
            var response = await _relatonshipsContext.SaveChangesAsync();

            if (response == 0) return Conflict("failed to save");

            return Ok("saved successfully");
        }
    }
}
