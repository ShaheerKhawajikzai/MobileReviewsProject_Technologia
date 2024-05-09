using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.RequestHandler.Devices
{
    public class GetDeviceBySlugModelRequestHandler : IRequestHandler<GetDeviceBySlugModelRequest, GetDeviceBySlugModelResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public GetDeviceBySlugModelRequestHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.db = applicationDbContext;
            this.mapper = mapper;
        }
        public async Task<GetDeviceBySlugModelResponse> Handle(GetDeviceBySlugModelRequest request, CancellationToken cancellationToken)
        {

            var deviceFromDb = await db.Devices.
                Include(b => b.Brand).
                Include(c => c.Comments).
                FirstOrDefaultAsync(d => d.Slug == request.Slug);

            if (deviceFromDb == null)
            {
                return null;
            }

            var response = new GetDeviceBySlugModelResponse()
            {
                Id = deviceFromDb.Id,
                BrandName = deviceFromDb.Brand.Name,
                BrandSlug = deviceFromDb.Brand.Slug,
                PriceInPKR = deviceFromDb.PriceInPKR,
                PriceInUSD = deviceFromDb.PriceInUSD,
                Description = deviceFromDb.Description,
                ImageUrl = deviceFromDb.ImageUrl,
                Model = deviceFromDb.Model,
                Slug = deviceFromDb.Slug,
                Comments = deviceFromDb.Comments.Select(x => new DeviceComments()
                {
                    Comment = x.UserComment,
                    DeviceId = x.DeviceId,
                    Name = x.UserName
                }).ToList()
            };

            return response;
        }
    }
}
