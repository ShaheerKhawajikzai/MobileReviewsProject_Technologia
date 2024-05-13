using AutoMapper;
using MobileReviewsProject.Models;
using MobileReviewsProject.Request.Admin;
using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.AutomapperProfiles.Admin
{
    public class AdminDeviceProfile : Profile
    {
        public AdminDeviceProfile()
        {
            CreateMap<Device, GetDevicesAdminModelResponse>();
      
        }
    }
}
