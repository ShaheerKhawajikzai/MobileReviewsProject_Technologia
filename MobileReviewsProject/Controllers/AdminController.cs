using Azure;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MobileReviewsProject.Models.Admin;
using MobileReviewsProject.Request.Admin;
using MobileReviewsProject.Request.Devices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using fl = System.IO;
using Microsoft.Identity.Client;
using MobileReviewsProject.Request.Brands;

namespace MobileReviewsProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IMediator Mediator { get; set; }
        public IWebHostEnvironment webHostEnvironment { get; }

        public AdminController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            this.Mediator = mediator;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index([FromQuery] GetDevicesAdminModelRequest request)
        {
            var data = await Mediator.Send(request);

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

            var response = await Mediator.Send(new EditDeviceModelRequest() { Device = obj });

            TempData["Success"] = response.Message;

            return RedirectToAction("Index", "Admin");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {

            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var login = await Mediator.Send(new LoginModelRequest() { Email = user.Email, Password = user.Password });

            if (login.IsSuccess)
            {
                var claims = GetClaims(login);

                //httpcontext.signinasync

                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();
                authProperties.ExpiresUtc = DateTime.UtcNow.AddDays(5);
                authProperties.IsPersistent = true;

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                TempData["Success"] = login.Message;
                return RedirectToAction(nameof(Index), "Admin");
            }

            TempData["Error"] = login.Message;

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshUrl()
        {
            var devices = await Mediator.Send(new GetDevicesAdminModelRequest());
            var brands = await Mediator.Send(new GetBrandsModelRequest());

            string wwwRootPath = webHostEnvironment.WebRootPath;
            string folderPath = Path.Combine(wwwRootPath, "sitemap.txt");

            var localHost = "https://localhost:7032/";
            List<string> url = new List<string>();

            foreach (var item in devices)
                url.Add(localHost + "device/" + item.Brand.Slug + "/" + item.Slug);

            foreach (var item in brands)
                url.Add(localHost + "device/" + item.Slug);


            fl.File.WriteAllLines(folderPath, url);

            return Json(new { isSuccess = true, Message= "Operation Performed Successfully." });
        }
        public List<Claim> GetClaims(LoginModelResponse user)
        {
            List<Claim> claims = new Claim[] {

            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),

            }.ToList();

            return claims;
        }
    }
}


