using HotelBookingApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Dtos.Response
{
    public class CreateHotelResDto
    {
        public CreateHotelResDto()
        {
            Facilities = new List<long>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public long City { get; set; }

        public List<long> Facilities { get; set; }
    }
}
