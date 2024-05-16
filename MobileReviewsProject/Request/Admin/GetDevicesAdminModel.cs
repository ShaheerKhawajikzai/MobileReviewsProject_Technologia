using MediatR;
using MobileReviewsProject.Models;

namespace MobileReviewsProject.Request.Admin
{
    public class GetDevicesAdminModelRequest : IRequest<List<GetDevicesAdminModelResponse>>
    {
        public string? Keyword { get; set; }

        public bool IsRefactor { get; set; }
    }
    public class GetDevicesAdminModelResponse
    {
        public int Id { get; set; }
        
        public string Model { get; set; }

     
        public string Description { get; set; }

     
        public string ImageUrl { get; set; }

        public int? PriceInPKRInt { get; set; }


        public string PriceInUSD { get; set; }

        public string OperatinSystem { get; set; }

     
        public string UserInterface { get; set; }

      
        public string Dimensions { get; set; }
     

        public string Weight { get; set; }

   
        public string Sim { get; set; }

  
        public string Colors { get; set; }

        public string TwoGBand { get; set; }

        public string ThreeGBand { get; set; }
        public string FourGBand { get; set; }
      
        public string FiveGBand { get; set; }
 
        public string CPU { get; set; }
      
        public string Chipset { get; set; }
        
        public string GPU { get; set; }

        public string? Radio { get; set; }

   
        public string Technology { get; set; }
  
        public string Resolution { get; set; }
     
        public string Protection { get; set; }
        
        public string ExtraFeatures { get; set; }
    
        public string BuiltIn { get; set; }
       
        public string Card { get; set; }
    
        public string Main { get; set; }
 
        public string Features { get; set; }
   
        public string Front { get; set; }
     
        public string WLAN { get; set; }

        public string Bluetooth { get; set; }
       
        public string GPS { get; set; }
      
        public string USB { get; set; }
   
        public string NFC { get; set; }
      
        public string Data { get; set; }
    
        public string Sensors { get; set; }
    
        public string Audio { get; set; }
  
        public string Browser { get; set; }

        public string Messaging { get; set; }
   
        public string Games { get; set; }
      
        public string Torch { get; set; }
      
        public string Extra { get; set; } = null!;

        public string Capacity { get; set; }

        public Brand Brand { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Slug { get; set; }

        public int View { get; set; }

    }
}
