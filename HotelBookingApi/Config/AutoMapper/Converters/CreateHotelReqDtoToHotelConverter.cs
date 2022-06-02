using AutoMapper;
using HotelBookingApi.Dtos.Request;
using HotelBookingApi.Dtos.Response;
using HotelBookingApi.Models;
using System.Collections.Generic;

namespace HotelBookingApi.Config.AutoMapper.Converters
{
    public class CreateHotelReqDtoToHotelConverter : ITypeConverter<CreateHotelReqDto, Hotel>
    {
        public Hotel Convert(CreateHotelReqDto source, Hotel destination, ResolutionContext context)
        {
            destination = new Hotel
            {
                Name = source.Name,
                Description = source.Description,
                Address = source.Address,
                Zip = source.Zip,
                CityId = source.City,
            };
            destination.HotelFacilities = source.Facilities.Select(x => new HotelFacility { FacilityId = x, Hotel = destination }).ToList();

            return destination;
        }
    }
}
