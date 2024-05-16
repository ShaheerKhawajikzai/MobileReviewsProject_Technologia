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
                Where(d => d.IsActive).
                FirstOrDefaultAsync(d => d.Slug == request.Slug);

            if (deviceFromDb == null)
            {
                return null;
            }

            var response = new GetDeviceBySlugModelResponse()
            {
                Device = mapper.Map<DeviceDto>(deviceFromDb),
                Comments = deviceFromDb.Comments.Select(x => new DeviceComments()
                {
                    Comment = x.UserComment,
                    DeviceId = x.DeviceId,
                    Name = x.UserName,
                    CreatedAt = x.CreatedAt
                }).ToList()
            };

            return response;
        }
    }
}
