using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MobileReviewsProject.Models.Admin
{
    public class User
    {
        public int Id { get; set; }

        [ValidateNever]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
