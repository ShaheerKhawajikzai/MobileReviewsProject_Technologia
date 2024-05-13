using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileReviewsProject.Models.Admin;
using MobileReviewsProject.Request.Admin;
using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.Controllers
{
    public class AdminController : Controller
    {
        public IMediator Mediator { get; set; }
        public IWebHostEnvironment webHostEnvironment { get; }

        public AdminController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            this.Mediator = mediator;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var data = await Mediator.Send(new GetDevicesAdminModelRequest());

            return View(data);
        }

        public async Task<IActionResult> EditDevice(string slug)
        {
            var data = await Mediator.Send(new GetDeviceBySlugModelRequest() { Slug = slug });

            var device = new EditDevice()
            {
                ProductId = data.Device.Id,
                Model = data.Device.Model,
                Description = data.Device.Description,
                PriceInPkr = data.Device.PriceInPKRInt.Value,
                PriceinUsd = data.Device.PriceInUSD,
                ImageUrl = data.Device.ImageUrl,
                Slug = data.Device.Slug,
                ReleasedDate = data.Device.ReleaseDate
            };

            return View(device);
        }

        [HttpPost]
        public async Task<IActionResult> EditDevice(EditDevice obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            var response = await Mediator.Send(new AddDeviceModelRequest() { Device = obj });

            TempData["Success"] = response.Message;

            return RedirectToAction("Index", "Admin");
        }


        public async Task<IActionResult> LogIn(User user)
        {
            return View();
        }
    }

}
