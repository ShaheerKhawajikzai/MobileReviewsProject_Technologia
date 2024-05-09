using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileReviewsProject.Helper;
using MobileReviewsProject.Request.Comments;
using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IMediator mediator;

        public DeviceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Device Detail Page
        [Route("device/{brand}/{slug}")]
        public async Task<IActionResult> GetDevice(string slug, string brand)
        {
            var device = await mediator.Send(new GetDeviceBySlugModelRequest() { Slug = slug });

            if (device == null)
                return RedirectToAction("NotFound", "Home");


            return View(device);
        }

        //Get All Device Based on Brand e.g get all Samsung mobiles
        [Route("device/{brand}")]
        public async Task<IActionResult> GetAllBrandDevices(string brand)
        {
            var data = await mediator.Send(new GetDevicesModelRequest() { BrandSlug = brand });
            return View(data);

           
        }

        [Route("/device/handlecomment")]
        [HttpPost]
        public async Task<IActionResult> HandleComment([FromBody] UserComment obj)
        {
            var data = await mediator.Send(new AddCommentModelRequest()
            {
                UserComment = obj.Comment,
                DeviceId = obj.DeviceId,
                UserName = obj.UserName
            });

            return Json(data);
        }
    }
}
