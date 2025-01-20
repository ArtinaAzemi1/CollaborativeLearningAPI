using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CollaborativeLearningAPI.Data.Repository
{
    public class GroupRepository
    {
        private CollaborativeLearningDBContext _context;

        public GroupRepository(CollaborativeLearningDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<List<Student>> GetGroupStudentsAsync(int groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Students)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);

            return group?.Students?.ToList() ?? new List<Student>();
        }

        public async void AddGroupAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async void UpdateGroupAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async void DeleteGroupAsync(int groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> GroupExistsAsync(int id)
        {
            return await _context.Groups.AnyAsync(g => g.GroupId == id);
        }
    }
}
