using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileReviewsProject.Models
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int? PriceInPKRInt { get; set; }

        [Required]
        public string PriceInUSD { get; set; }
        [Required]
        public string OperatinSystem { get; set; }

        [Required]
        public string UserInterface { get; set; }

        [Required]
        public string Dimensions { get; set; }
        [Required]

        public string Weight { get; set; }

        [Required]
        public string Sim { get; set; }

        [Required]
        public string Colors { get; set; }
        [Required]
        public string TwoGBand { get; set; }
        [Required]
        public string ThreeGBand { get; set; }
        [Required]
        public string FourGBand { get; set; }
        [Required]
        public string FiveGBand { get; set; }
        [Required]
        public string CPU { get; set; }
        [Required]
        public string Chipset { get; set; }
        [Required]
        public string GPU { get; set; }

        public string? Radio { get; set; }

        [Required]
        public string Technology { get; set; }
        [Required]
        public string Resolution { get; set; }
        [Required]
        public string Protection { get; set; }
        [Required]
        public string ExtraFeatures { get; set; }
        [Required]
        public string BuiltIn { get; set; }
        [Required]
        public string Card { get; set; }
        [Required]
        public string Main { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public string Front { get; set; }
        [Required]
        public string WLAN { get; set; }
        [Required]
        public string Bluetooth { get; set; }
        [Required]
        public string GPS { get; set; }
        [Required]
        public string USB { get; set; }
        [Required]
        public string NFC { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string Sensors { get; set; }
        [Required]
        public string Audio { get; set; }
        [Required]
        public string Browser { get; set; }
        [Required]
        public string Messaging { get; set; }
        [Required]
        public string Games { get; set; }
        [Required]
        public string Torch { get; set; }
        [Required]
        public string Extra { get; set; } = null!;

        [Required]
        public string Capacity { get; set; }

        [Required]

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string? Slug { get; set; }

        public int View { get; set; }

        public bool IsActive { get; set; }

        public bool IsRefactor { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
