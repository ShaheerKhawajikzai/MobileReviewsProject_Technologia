using System.ComponentModel.DataAnnotations.Schema;

namespace MobileReviewsProject.Models
{
    public class DeviceOldNewSlug
    {
        public int Id { get; set; }
        public string OldSlug { get; set; }
        public string NewSlug { get; set; }

        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }

        public Device Device { get; set; }
    }
}
