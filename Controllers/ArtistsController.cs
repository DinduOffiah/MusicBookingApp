using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBookingApp.Data;
using MusicBookingApp.Models;

namespace MusicBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ArtistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET: api/artists/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return NotFound();
            return artist;
        }

        // POST: api/artists
        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtist), new { id = artist.ArtistId }, artist);
        }

        // PUT: api/artists/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId) return BadRequest();
            _context.Entry(artist).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Artists.Any(a => a.ArtistId == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/artists/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return NotFound();
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
