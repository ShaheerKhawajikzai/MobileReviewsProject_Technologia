using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Request.Admin;

namespace MobileReviewsProject.RequestHandler.Admin
{

    public class LoginModelRequestHandler : IRequestHandler<LoginModelRequest, LoginModelResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        public LoginModelRequestHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<LoginModelResponse> Handle(LoginModelRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            if (user.Password == request.Password && user.Email == request.Email)
            {
                return new LoginModelResponse() { IsSuccess = true, Message = "Login Successful", Id = user.Id, Name = user.Name, Email = user.Email, Password = user.Password };
            }

            return new LoginModelResponse() { IsSuccess = false, Message = "Login Failed" };

        }
    }
}
