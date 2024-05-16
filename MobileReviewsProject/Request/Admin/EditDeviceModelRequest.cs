using MediatR;
using MobileReviewsProject.Helper;
using MobileReviewsProject.Models.Admin;

namespace MobileReviewsProject.Request.Admin
{
    public class EditDeviceModelRequest : IRequest<EditDeviceModelResponse>
    {
        public EditDevice Device { get; set; }
    }

    public class EditDeviceModelResponse : BaseResponse
    {
    }
}
