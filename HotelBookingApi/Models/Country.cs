using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Country
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IList<City> Cities { get; set; }
    }
}
