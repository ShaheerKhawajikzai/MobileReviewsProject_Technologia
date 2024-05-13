using MediatR;
using Microsoft.Identity.Client;
using MobileReviewsProject.Data;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Comments;

namespace MobileReviewsProject.RequestHandler.Comments
{
    public class AddCommentModelRequestHandler : IRequestHandler<AddCommentModelRequest, AddCommentModelResponse>
    {
        private readonly ApplicationDbContext db;

        public AddCommentModelRequestHandler(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<AddCommentModelResponse> Handle(AddCommentModelRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.UserComment) || request.DeviceId <= 0)
            {
                return new AddCommentModelResponse() { IsSuccess = false, Message = "Something went wrong" };
            }
            var obj = new Comment()
            {
                DeviceId = request.DeviceId,
                UserComment = request.UserComment,
                UserName = request.UserName,
                CreatedAt = DateTime.UtcNow
            };

            await db.Comments.AddAsync(obj);
            await db.SaveChangesAsync();

            return new AddCommentModelResponse() { IsSuccess = true, Message = "Thanks for your valuable feedback" };

        }
    }
}
