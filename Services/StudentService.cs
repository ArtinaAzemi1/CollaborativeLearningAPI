using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Data.Repository;
using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetStudents();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }
            return student;
        }
        public async void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
            {
                throw new Exception("Student name cannot be empty.");
            }
             _studentRepository.AddStudentAsync(student);
        }

        public async void UpdateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
            {
                throw new Exception("Student name cannot be empty.");
            }
            _studentRepository.UpdateStudentAsync(student);
        }

        public async void DeleteStudent(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new Exception("Cannot delete student that does not exist.");
            }
             _studentRepository.DeleteStudent(id);
        }
    }
}
