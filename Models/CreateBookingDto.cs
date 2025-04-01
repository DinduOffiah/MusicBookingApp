namespace MusicBookingApp.Models
{
    public class CreateBookingDto
    {
        public int EventId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public decimal Amount { get; set; }
    }
}
