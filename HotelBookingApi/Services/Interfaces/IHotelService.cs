using HotelBookingApi.Dtos.Request;
using HotelBookingApi.Dtos.Response;
using HotelBookingApi.Models;

namespace HotelBookingApi.Services.Interfaces
{
    public interface IHotelService
    {
        Hotel Get(long id);
        List<Hotel> Get();
    }
}
