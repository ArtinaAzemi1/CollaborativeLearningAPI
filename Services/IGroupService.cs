using CollaborativeLearningAPI.Models;

namespace CollaborativeLearningAPI.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task<List<Student>> GetGroupStudentsAsync(int groupId);
        public void AddGroup(Group group);
        public void UpdateGroup(Group group);
        public void DeleteGroup(int id);
    }
}
