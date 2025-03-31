using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBookingApp.Data;
using MusicBookingApp.Models;

namespace MusicBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.Include(e => e.Artist).ToListAsync();
        }

        // GET: api/events/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var evt = await _context.Events.Include(e => e.Artist)
                                           .FirstOrDefaultAsync(e => e.EventId == id);
            if (evt == null) return NotFound();
            return evt;
        }

        // POST: api/events
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event evt)
        {
            _context.Events.Add(evt);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { id = evt.EventId }, evt);
        }

        // PUT: api/events/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event evt)
        {
            if (id != evt.EventId) return BadRequest();
            _context.Entry(evt).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Events.Any(e => e.EventId == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/events/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null) return NotFound();
            _context.Events.Remove(evt);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
