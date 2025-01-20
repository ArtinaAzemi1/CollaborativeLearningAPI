using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : ControllerBase
    {
        private readonly CollaborativeLearningDBContext _context;

        public AssistantController(CollaborativeLearningDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assistant>>> GetAssistants()
        {
            return await _context.Assistant.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assistant>> GetAssistantById(int id)
        {
            var assistant = await _context.Assistant.FindAsync(id);

            if (assistant == null)
            {
                return NotFound();
            }

            return assistant;
        }

        private bool AssistantExists(int id)
        {
            return _context.Assistant.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> PostAssistant(Assistant assistant)
        {
            _context.Assistant.Add(assistant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssistantById", new { id = assistant.Id }, assistant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssistant(int id, Assistant assistant)
        {
            if (id != assistant.Id)
            {
                return BadRequest();
            }

            _context.Entry(assistant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssistant(int id)
        {
            var assistant = await _context.Assistant.FindAsync(id);
            if (assistant == null)
            {
                return NotFound();
            }

            _context.Assistant.Remove(assistant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
