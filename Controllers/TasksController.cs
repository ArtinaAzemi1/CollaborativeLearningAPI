using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly CollaborativeLearningDBContext _context;

        public TasksController(CollaborativeLearningDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Tasks task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTasks(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.TaskId }, task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
