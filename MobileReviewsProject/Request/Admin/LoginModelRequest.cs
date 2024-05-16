using MediatR;
using MobileReviewsProject.Helper;

namespace MobileReviewsProject.Request.Admin
{
    public class LoginModelRequest : IRequest<LoginModelResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginModelResponse : BaseResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
