using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBookingApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        // Foreign key to event
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Required]
        public string? CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public DateTime BookingDate { get; set; }

        public decimal Amount { get; set; }
    }
}
