using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Request.Search;

namespace MobileReviewsProject.RequestHandler.Search
{

    public class SearchModelRequestHandler : IRequestHandler<SearchModelRequest, List<SearchModelResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper mapper;
        public SearchModelRequestHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<SearchModelResponse>> Handle(SearchModelRequest request, CancellationToken cancellationToken)
        {
            var devices = _dbContext.Devices.Include(x => x.Brand).Where(x =>
            (string.IsNullOrWhiteSpace(request.Keyword) || x.Model.Contains(request.Keyword) || x.Brand.Name.Contains(request.Keyword))
            &&
            (x.IsActive)
            ).ToList();


            var response = devices.Select(d => new SearchModelResponse()
            {
                Id = d.Id,
                BrandName = d.Brand.Name,
                BrandSlug = d.Brand.Slug,
                Model = d.Model,
                Description = d.Description,
                Slug = d.Slug,
                PriceInUSD = d.PriceInUSD,
                PriceInPKR = d.PriceInPKRInt,
                ImageUrl = d.ImageUrl,
                ReleaseDate = d.ReleaseDate

            }).ToList();


            return response;

        }
    }
}
