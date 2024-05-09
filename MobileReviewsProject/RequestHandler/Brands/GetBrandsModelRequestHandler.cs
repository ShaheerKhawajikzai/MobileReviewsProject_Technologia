using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Request.Brands;

namespace MobileReviewsProject.RequestHandler.Brands
{
    public class GetBrandsModelRequestHandler : IRequestHandler<GetBrandsModelRequest, List<GetBrandsModelResponse>>
    {
        private readonly ApplicationDbContext db;

        public GetBrandsModelRequestHandler(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
        }
        public async Task<List<GetBrandsModelResponse>> Handle(GetBrandsModelRequest request, CancellationToken cancellationToken)
        {
            var listOfBrands = await db.Brands.Select(b => new GetBrandsModelResponse()
            {
                Id = b.Id,
                Name = b.Name,
                Slug = b.Slug

            }).ToListAsync();

            return listOfBrands;
        }
    }
}
