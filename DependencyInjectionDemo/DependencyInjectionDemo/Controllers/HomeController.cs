using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMyService _myService;

        public HomeController(IMyService myService)
        {
            _myService = myService;
        }
        [HttpGet("message")]

        public IActionResult GetMessage()
        {
            var message = _myService.GetMessage();

            return Ok(message);
        }
    }
}
