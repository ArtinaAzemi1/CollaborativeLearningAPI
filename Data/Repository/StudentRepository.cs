using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CollaborativeLearningAPI.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollaborativeLearningDBContext _context;
        public StudentRepository(CollaborativeLearningDBContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id); 
        }


    }
}
