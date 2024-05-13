using AutoMapper;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.AutomapperProfiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>();
        }
    }
}
