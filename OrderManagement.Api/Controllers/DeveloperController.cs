using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("Developers")]
    public class DeveloperController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestFunction()
        {
            return Ok();
        }
    }
}
