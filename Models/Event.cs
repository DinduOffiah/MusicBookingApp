using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBookingApp.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Venue { get; set; }

        public DateTime EventDate { get; set; }

        // Foreign Key: each event is associated with one artist
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
