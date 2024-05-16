using MediatR;

namespace MobileReviewsProject.Request.Search
{
    public class SearchModelRequest :IRequest<List<SearchModelResponse>>
    {
        public string? Keyword { get; set; }
    }

    public class SearchModelResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public int? PriceInPKR { get; set; }
        public string PriceInUSD { get; set; }
        public string Slug { get; set; }
        public string BrandSlug { get; set; }
        public string BrandName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
