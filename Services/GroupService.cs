using CollaborativeLearningAPI.Data.Repository;
using CollaborativeLearningAPI.Models;

namespace CollaborativeLearningAPI.Services
{
    public class GroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _groupRepository.GetAllGroupsAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null)
            {
                throw new Exception("Group not found.");
            }
            return group;
        }
        public async void AddGroup(Group group)
        {
            if (string.IsNullOrWhiteSpace(group.GroupName))
            {
                throw new Exception("Group name cannot be empty.");
            }
            _groupRepository.AddGroupAsync(group);
        }

        public async void UpdateGroup(Group group)
        {
            if (string.IsNullOrWhiteSpace(group.GroupName))
            {
                throw new Exception("Group name cannot be empty.");
            }
            _groupRepository.UpdateGroupAsync(group);
        }

        public async void DeleteStudent(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null)
            {
                throw new Exception("Cannot delete group that does not exist.");
            }
            _groupRepository.DeleteGroupAsync(id);
        }

        public async Task<List<Student>> GetGroupStudentsAsync(int groupId)
        {
            var students = await _groupRepository.GetGroupStudentsAsync(groupId);
            if (students == null || !students.Any())
            {
                throw new Exception("No students found for this group.");
            }
            return students;
        }
    }
}
