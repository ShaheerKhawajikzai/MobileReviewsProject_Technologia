using MediatR;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Brands;

namespace MobileReviewsProject.Helper
{
    public class Brands
    {
        private readonly IMediator mediator;

        public Brands(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async  Task <List<GetBrandsModelResponse>> GetBrands()
        {
           var data =await mediator.Send(new GetBrandsModelRequest());
            return data;
        } 

    }
}
