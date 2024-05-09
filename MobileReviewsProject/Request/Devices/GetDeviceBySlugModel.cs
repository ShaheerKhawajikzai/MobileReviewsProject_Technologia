using MediatR;
using MobileReviewsProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobileReviewsProject.Request.Devices
{
    public class GetDeviceBySlugModelRequest : IRequest<GetDeviceBySlugModelResponse>
    {
        public string Slug { get; set; }
    }

    public class GetDeviceBySlugModelResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public string PriceInPKR { get; set; }
        public string PriceInUSD { get; set; }
        public string Slug { get; set; }
        public string BrandSlug { get; set; }
        public string BrandName { get; set; }
        public List<DeviceComments> Comments { get; set; }
    }
    public class DeviceComments
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public int DeviceId { get; set; }
    }
}
