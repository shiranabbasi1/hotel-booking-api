using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class City
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}
