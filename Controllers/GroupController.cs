using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Models;
using CollaborativeLearningAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var group = await _groupService.GetAllGroupsAsync();
            return Ok(group);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            try
            {
                var group = await _groupService.GetGroupByIdAsync(id);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}/Students")]
        public async Task<ActionResult<List<Student>>> GetGroupsStudents(int id)
        {
            try
            {
                var students = await _groupService.GetGroupStudentsAsync(id);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            /*var group = await _context.Groups.Include(x => x.Students).Where(x => x.GroupId == id).FirstOrDefaultAsync();

            if (group == null)
            {
                return NotFound();
            }
            List<Student> students = group.Students.ToList();

            return students;*/
        }

        [HttpPut("{groupId}")]
        public async Task<IActionResult> PutGroup(int groupId, Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (groupId != group.GroupId)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            try
            {
                _groupService.UpdateGroup(group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _groupService.AddGroup(group);
                return CreatedAtAction(nameof(GetGroup), new { id = group.GroupId }, group);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                _groupService.DeleteGroup(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
