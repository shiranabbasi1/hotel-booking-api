using AutoMapper;
using HotelBookingApi.Dtos.Request;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories.Interfaces;
using HotelBookingApi.Services.Interfaces;
using System.Collections.Generic;

namespace HotelBookingApi.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper _mapper;
        public HotelService(IGenericRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Hotel Get(long id)
        {
            Hotel result = _repository.Get<Hotel>(id);
            return result;
        }

        public List<Hotel> Get()
        {
            List<Hotel> result = _repository.Get<Hotel>();
            return result;
        }
    }
}
