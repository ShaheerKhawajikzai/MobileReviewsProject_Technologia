using MobileReviewsProject.Request.Devices;

namespace MobileReviewsProject.Helper.Devices
{
    public class DevicesModel
    {
        public List<GetDevicesModelResponse> ListOflatestDevice { get; set; }
        public List<GetDevicesModelResponse> DevicesLessThan20k { get; set; }
        public List<GetDevicesModelResponse> DevicesLessThan30k { get; set; }
        public List<GetDevicesModelResponse> DevicesLessThan50k { get; set; }

    }
}
