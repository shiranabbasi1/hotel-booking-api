using HotelBookingApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Dtos.Request
{
    public class CreateHotelReqDto
    {
        public CreateHotelReqDto()
        {
            Facilities = new List<long>();
        }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Address { get; set; }
        
        public string Zip { get; set; }
        
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid city")]
        public long City { get; set; }
        [ListMin(1, "Invalid facility")]        
        
        public List<long> Facilities { get; set; }
    }
}
