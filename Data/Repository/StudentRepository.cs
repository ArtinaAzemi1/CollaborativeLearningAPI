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

        public async void AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async void UpdateStudentAsync (Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }


        public async void DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

    }
}
