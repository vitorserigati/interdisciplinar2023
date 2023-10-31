using System.ComponentModel.DataAnnotations;

namespace Interdisciplinar2023.Models
{
    public class Provider
    {
        [Key]
        public Guid Id { get; set; }

        public string? Document { get; set; }

        public string? CorporateName { get; set; }

        public string? Street { get; set; }

        public string? Neighborhood { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Celphone { get; set; }

        public IEnumerable<Product?> Products { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
