﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileReviewsProject.Data;
using MobileReviewsProject.Request.Devices;
using System.Runtime.InteropServices;

namespace MobileReviewsProject.RequestHandler.Devices
{
    public class GetDeviceModelRequestHandler : IRequestHandler<GetDevicesModelRequest, List<GetDevicesModelResponse>>
    {
        private readonly ApplicationDbContext _db;
        public GetDeviceModelRequestHandler(ApplicationDbContext applicationDbContext)
        {
            this._db = applicationDbContext;
        }
        public async Task<List<GetDevicesModelResponse>> Handle(GetDevicesModelRequest request, CancellationToken cancellationToken)
        {


            var listOfDevices = await _db.Devices.Include(x => x.Brand)
               .Where(d => (string.IsNullOrWhiteSpace(request.BrandSlug) ||
                d.Brand.Slug.ToLower() == request.BrandSlug.ToLower())
                &&
                (d.IsActive))

                .Select(d =>
                new GetDevicesModelResponse()
                {
                    Id = d.Id,
                    Model = d.Model,
                    Description = d.Description,
                    Slug = d.Slug,
                    BrandSlug = d.Brand.Slug,
                    BrandName = d.Brand.Name,
                    ImageUrl = d.ImageUrl,
                    PriceInPKR = d.PriceInPKRInt,
                    PriceInUSD = d.PriceInUSD,
                    ReleaseDate = d.ReleaseDate

                }).ToListAsync();

            return listOfDevices;
        }
    }
}
