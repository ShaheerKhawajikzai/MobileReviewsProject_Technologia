using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileReviewsProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]

        public string UserComment { get; set; }
        [Required]

        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
