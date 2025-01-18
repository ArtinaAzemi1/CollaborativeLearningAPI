using CollaborativeLearningAPI.Models;

namespace CollaborativeLearningAPI.Data.Repository
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task<List<Student>> GetGroupStudentsAsync(int groupId);
        public void AddGroupAsync(Group group);
        public void UpdateGroupAsync(Group group);
        public void DeleteGroupAsync(int groupId);
        Task<bool> GroupExistsAsync(int id);
    }
}
