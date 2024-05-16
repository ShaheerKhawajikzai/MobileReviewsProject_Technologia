using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Admin;
using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.RequestHandler.Admin
{
    public class EditDeviceModelRequestHandler : IRequestHandler<EditDeviceModelRequest, EditDeviceModelResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMediator Mediator;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EditDeviceModelRequestHandler(ApplicationDbContext dbContext, IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            this._dbContext = dbContext;
            this.Mediator = mediator;
            this.webHostEnvironment = webHostEnvironment;

        }
        public async Task<EditDeviceModelResponse> Handle(EditDeviceModelRequest request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FirstOrDefaultAsync(d => d.Id == request.Device.ProductId);


            if (device.Slug.ToLower() != request.Device.Slug.ToLower())
            {
                var deviceOldNewSlug = new DeviceOldNewSlug()
                {
                    DeviceId = device.Id,
                    OldSlug = device.Slug,
                    NewSlug = request.Device.Slug
                };

                _dbContext.DevicesOldNewSlug.Add(deviceOldNewSlug);
                await _dbContext.SaveChangesAsync();
            }

            device.Model = request.Device.Model;
            device.Description = request.Device.Description;
            device.PriceInPKRInt = request.Device.PriceInPkr;
            device.PriceInUSD = request.Device.PriceinUsd;
            device.ReleaseDate = request.Device.ReleasedDate;
            device.Slug = request.Device.Slug;
            device.IsActive = request.Device.IsActive;



            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(request.Device.Image?.FileName);

            if (request.Device.Image != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string folderPath = @"images\";

                string oldImagePath = Path.Combine(wwwRootPath, request.Device.ImageUrl.TrimStart('\\'));

                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
                string finalPath = Path.Combine(wwwRootPath, folderPath);

                using (var fileStream = new FileStream(Path.Combine(finalPath, imageName), FileMode.Create))
                {
                    request.Device.Image.CopyTo(fileStream);
                }

                device.ImageUrl = @"\" + folderPath + imageName;
            }


            _dbContext.Devices.Update(device);
            await _dbContext.SaveChangesAsync();

            return new EditDeviceModelResponse() { IsSuccess = true, Message = "Device Updated Successfully." };

        }
    }
}
