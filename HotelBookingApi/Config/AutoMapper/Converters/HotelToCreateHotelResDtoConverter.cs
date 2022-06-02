using AutoMapper;
using HotelBookingApi.Dtos.Request;
using HotelBookingApi.Dtos.Response;
using HotelBookingApi.Models;
using System.Collections.Generic;

namespace HotelBookingApi.Config.AutoMapper.Converters
{
    public class HotelToCreateHotelResDtoConverter : ITypeConverter<Hotel, CreateHotelResDto>
    {
        public CreateHotelResDto Convert(Hotel source, CreateHotelResDto destination, ResolutionContext context)
        {
            destination = new CreateHotelResDto
            {
                Name = source.Name,
                Description = source.Description,
                Address = source.Address,
                Zip = source.Zip,
                City = source.CityId,
                Facilities = source.HotelFacilities.Select(x => x.FacilityId).ToList()
            };

            return destination;
        }
    }
}
