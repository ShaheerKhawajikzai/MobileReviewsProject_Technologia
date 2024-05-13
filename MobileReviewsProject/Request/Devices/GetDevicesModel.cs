using MediatR;
using MobileReviewsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileReviewsProject.Request.Devices
{
    public class GetDevicesModelRequest : IRequest<List<GetDevicesModelResponse>>
    {
        public string? BrandSlug { get; set; }
    }
    public class GetDevicesModelResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public int? PriceInPKR { get; set; }
        public string PriceInUSD { get; set; }
        public string Slug { get; set; }
        public string BrandSlug { get; set; }
        public string BrandName { get; set; }

        public DateTime ReleaseDate { get; set; }

    }

  
}
