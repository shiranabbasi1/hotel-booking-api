using AutoMapper;
using HotelBookingApi.Dtos.Request;
using HotelBookingApi.Dtos.Response;
using HotelBookingApi.Models;
using HotelBookingApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(ApplicationContext context,
            IHotelService hotelService,
            IMapper mapper)
        {
            _context = context;
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetHotels()
        {
            List<Hotel> result = _hotelService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotel(long id)
        {
            Hotel result = _hotelService.Get(id);
            if (result == null)
                return NotFound();
            CreateHotelResDto response = _mapper.Map<CreateHotelResDto>(result);
            return Ok(response);
        }
    }
}
