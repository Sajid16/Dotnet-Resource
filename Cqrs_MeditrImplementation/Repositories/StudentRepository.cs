using Cqrs_MeditrImplementation.Data;
using Cqrs_MeditrImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace Cqrs_MeditrImplementation.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextClass _dbContext;

        public StudentRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _dbContext.StudentsCqrs.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var filteredData = _dbContext.StudentsCqrs.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.StudentsCqrs.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int Id)
        {
            return await _dbContext.StudentsCqrs.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _dbContext.StudentsCqrs.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _dbContext.StudentsCqrs.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
