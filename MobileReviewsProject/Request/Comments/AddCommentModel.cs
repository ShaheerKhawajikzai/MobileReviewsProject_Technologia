using MediatR;
using MobileReviewsProject.Helper;

namespace MobileReviewsProject.Request.Comments
{
    public class AddCommentModelRequest : IRequest<AddCommentModelResponse>
    {
        public string UserName { get; set; }
        public string UserComment { get; set; }
        public int DeviceId { get; set; }
    }

    public class AddCommentModelResponse : BaseResponse
    {
  
    }
}
