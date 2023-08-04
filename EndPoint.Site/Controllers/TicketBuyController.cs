using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class TicketBuyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
