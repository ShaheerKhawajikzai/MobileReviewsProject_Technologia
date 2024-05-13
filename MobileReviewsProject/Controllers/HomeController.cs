using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Helper.Devices;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Devices;
using System.Diagnostics;

namespace MobileReviewsProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMediator mediatR;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.mediatR = mediator;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
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
