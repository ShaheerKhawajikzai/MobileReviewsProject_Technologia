using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Helper.Cache;
using MobileReviewsProject.Helper.Devices;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Devices;
using MobileReviewsProject.Request.Search;
using System.Diagnostics;


namespace MobileReviewsProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMediator mediatR;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.mediatR = mediator;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(GetDevicesModelRequest request)
        {
            var response = await mediatR.Send(new GetDevicesModelRequest());

            DevicesModel listOfDevices = new DevicesModel
            {

                DevicesLessThan20k = response.Where(x => (x.PriceInPKR != null && x.PriceInPKR < 20000)).ToList(),
                DevicesLessThan30k = response.Where(x => (x.PriceInPKR != null && x.PriceInPKR < 30000)).ToList(),
                DevicesLessThan50k = response.Where(x => (x.PriceInPKR != null && x.PriceInPKR < 50000)).ToList(),
                ListOflatestDevice = response.OrderBy(x => x.ReleaseDate).ToList()
            };

            return View(listOfDevices);
        }

        [Route("/search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var response = await mediatR.Send(new SearchModelRequest() { Keyword = keyword });
            ViewBag.Keyword = keyword;

            return View(response);
        }
        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
