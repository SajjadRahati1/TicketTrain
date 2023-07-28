using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// سفارشات
        /// </summary>
        /// <returns></returns>
        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Passengers() {
            return View();
        }
        public IActionResult Transactions() {
            return View();
        }
    }
}
