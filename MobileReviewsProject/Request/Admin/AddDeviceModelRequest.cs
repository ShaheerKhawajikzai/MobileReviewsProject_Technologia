using MediatR;
using MobileReviewsProject.Helper;
using MobileReviewsProject.Models.Admin;

namespace MobileReviewsProject.Request.Admin
{
    public class AddDeviceModelRequest : IRequest<AddDeviceModelResponse>
    {
        public EditDevice Device { get; set; }
    }

    public class AddDeviceModelResponse : BaseResponse
    {
    }
}
