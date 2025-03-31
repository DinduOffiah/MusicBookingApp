using System.ComponentModel.DataAnnotations;

namespace MusicBookingApp.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Bio { get; set; }

        public string? Genre { get; set; }
    }
}
