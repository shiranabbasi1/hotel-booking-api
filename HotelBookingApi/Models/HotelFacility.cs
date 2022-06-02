namespace HotelBookingApi.Models
{
    public class HotelFacility
    {
        public long HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public long FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
