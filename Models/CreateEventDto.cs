namespace MusicBookingApp.Models
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public DateTime EventDate { get; set; }
        public int ArtistId { get; set; }
    }
}
