using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Apis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[Area]/[Controller]")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
