using Cqrs_MeditrImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace Cqrs_MeditrImplementation.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<StudentDetails> StudentsCqrs { get; set; }
    }
}
