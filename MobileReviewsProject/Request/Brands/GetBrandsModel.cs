using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MobileReviewsProject.Request.Brands
{
    public class GetBrandsModelRequest : IRequest<List<GetBrandsModelResponse>>
    {
    }

    public class GetBrandsModelResponse
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}
