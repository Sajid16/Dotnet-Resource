﻿using Cqrs_MeditrImplementation.Models;

namespace Cqrs_MeditrImplementation.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<StudentDetails>> GetStudentListAsync();
        public Task<StudentDetails> GetStudentByIdAsync(int Id);
        public Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        Task<bool> AddStudentAllAsync(List<StudentDetails> studentDetails);
        public Task<int> UpdateStudentAsync(StudentDetails studentDetails);
        public Task<bool> UpdateStudentListAsync(List<StudentDetails> studentDetails);
        public Task<int> DeleteStudentAsync(int Id);
    }
}
