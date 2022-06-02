using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("status")]
        public IActionResult Index()
        {
            string env = _configuration.GetSection("enviornmentName").Value;
            string build = _configuration.GetSection("buildNumber").Value;
            return Ok(new {
                enviornmentName = env,
                buildNumber = build
            });
        }
    }
}