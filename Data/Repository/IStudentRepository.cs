using CollaborativeLearningAPI.Models;

namespace CollaborativeLearningAPI.Data.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
    }
}
