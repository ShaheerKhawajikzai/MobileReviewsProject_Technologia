using System.ComponentModel.DataAnnotations;

namespace MobileReviewsProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Slug { get; set; }

    }
}
