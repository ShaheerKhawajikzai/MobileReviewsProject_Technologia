    using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.AutomapperProfiles;
using MobileReviewsProject.Data;
using MobileReviewsProject.Request.Admin;

namespace MobileReviewsProject.RequestHandler.Admin
{
    public class GetDevicesAdminModelRequestHandler : IRequestHandler<GetDevicesAdminModelRequest, List<GetDevicesAdminModelResponse>>
    {
        public ApplicationDbContext _dbContext { get; set; }
        public IMapper Mapper { get; set; }

        public GetDevicesAdminModelRequestHandler(ApplicationDbContext _dbContext, IMapper mapper)
        {
            this._dbContext = _dbContext;
            this.Mapper = mapper;
        }


        public async Task<List<GetDevicesAdminModelResponse>> Handle(GetDevicesAdminModelRequest request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Devices.Include(x => x.Brand)
                .Where(d =>
                (string.IsNullOrWhiteSpace(request.Keyword) || d.Model.Contains(request.Keyword) || d.Brand.Name.Contains(request.Keyword))
                &&
                (!request.IsRefactor || d.IsRefactor)
                ).ToListAsync();



            var getDevicesAdminModelResponses = Mapper.Map<List<GetDevicesAdminModelResponse>>(data);

            return getDevicesAdminModelResponses;

        }
    }
}
