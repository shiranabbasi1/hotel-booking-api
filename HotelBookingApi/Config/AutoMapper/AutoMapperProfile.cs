using AutoMapper;
using HotelBookingApi.Config.AutoMapper.Converters;
using HotelBookingApi.Dtos.Request;
using HotelBookingApi.Dtos.Response;
using HotelBookingApi.Models;

namespace HotelBookingApi.Config.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateHotelReqDto, Hotel>().ConvertUsing<CreateHotelReqDtoToHotelConverter>();
            CreateMap<Hotel, CreateHotelResDto>().ConvertUsing<HotelToCreateHotelResDtoConverter>();
        }
    }
}
