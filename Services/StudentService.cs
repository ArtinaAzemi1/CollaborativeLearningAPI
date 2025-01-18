using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Services
{
    public class StudentService : IStudentService
    {

        private readonly CollaborativeLearningDBContext _context;

        public StudentService(CollaborativeLearningDBContext context)
        {
            _context = context;
        }
        public void AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }


    }
}
