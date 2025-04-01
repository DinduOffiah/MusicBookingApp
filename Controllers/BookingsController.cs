using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBookingApp.Data;
using MusicBookingApp.Models;

namespace MusicBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                                 .Include(b => b.Event)
                                 .ThenInclude(e => e.Artist)
                                 .ToListAsync();
        }

        // GET: api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings
                                        .Include(b => b.Event)
                                        .ThenInclude(e => e.Artist)
                                        .FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null) return NotFound();
            return booking;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(CreateBookingDto dto)
        {
            var evt = await _context.Events.FindAsync(dto.EventId);
            if (evt == null)
            {
                return BadRequest("Event with the provided ID does not exist.");
            }

            var booking = new Booking
            {
                EventId = dto.EventId,  
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                Amount = dto.Amount,
                BookingDate = DateTime.Now
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }


        // PUT: api/bookings/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, Booking booking)
        {
            if (id != booking.BookingId) return BadRequest();
            _context.Entry(booking).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(b => b.BookingId == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/bookings/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
