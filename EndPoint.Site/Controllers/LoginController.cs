using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signin(long id)
        {
            return RedirectToAction("Index", new { id });
        }
    }
}
