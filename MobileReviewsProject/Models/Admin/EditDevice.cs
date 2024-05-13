using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileReviewsProject.Models.Admin
{
    public class EditDevice
    {
        public int ProductId { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]

        [DisplayName("Price in PKR")]
        public int PriceInPkr { get; set; }

        [Required]
        [DisplayName("Price in USD")]
        public string PriceinUsd { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }

        [DisplayName("Release Date")]
        public DateTime ReleasedDate { get; set; }
        public string Slug { get; set; }
    }
}
