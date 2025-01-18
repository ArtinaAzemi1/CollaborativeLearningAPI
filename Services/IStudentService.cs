using CollaborativeLearningAPI.Models;

namespace CollaborativeLearningAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        public void AddStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);

    }
}
