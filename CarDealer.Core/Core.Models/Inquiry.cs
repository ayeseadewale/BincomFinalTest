using CarDealer.Core.Core.Models;

namespace CarDealer.Core.Core.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        // User Information
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        // Car Information
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
