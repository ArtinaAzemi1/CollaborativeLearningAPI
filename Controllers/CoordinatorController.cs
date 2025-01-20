using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatorController : ControllerBase
    {
        private readonly CollaborativeLearningDBContext _context;

        public CoordinatorController(CollaborativeLearningDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordinator>>> GetCoordinators()
        {
            return await _context.Coordinator.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Coordinator>> GetCoordinatorById(int id)
        {
            var coordinator = await _context.Coordinator.FindAsync(id);

            if (coordinator == null)
            {
                return NotFound();
            }

            return coordinator;
        }

        private bool CoordinatorExists(int id)
        {
            return _context.Coordinator.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Coordinator>> PostCoordinator(Coordinator coordinator)
        {
            _context.Coordinator.Add(coordinator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordinatorById", new { id = coordinator.Id }, coordinator);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordinator(int id, Coordinator coordinator)
        {
            if (id != coordinator.Id)
            {
                return BadRequest();
            }

            _context.Entry(coordinator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordinatorExists(id))
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
        public async Task<IActionResult> DeleteCoordinator(int id)
        {
            var coordinator = await _context.Coordinator.FindAsync(id);
            if (coordinator == null)
            {
                return NotFound();
            }

            _context.Coordinator.Remove(coordinator);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
