using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.UserAccounting.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiController]
    [Area("UserAccounting")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
