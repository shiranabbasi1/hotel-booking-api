using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Hotel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        [Required]
        public long CityId { get; set; }
        public virtual City City { get; set; }
        public virtual IList<HotelFacility> HotelFacilities { get; set; }
    }
}
