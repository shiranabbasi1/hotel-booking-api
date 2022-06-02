using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Facility
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<HotelFacility> HotelFacilities { get; set; }
    }
}
