using CollaborativeLearningAPI.Models;

namespace CollaborativeLearningAPI.Data.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);

        public void AddStudentAsync(Student student);

        public void UpdateStudentAsync(Student student);

        public void DeleteStudent(int id);
    }
}
