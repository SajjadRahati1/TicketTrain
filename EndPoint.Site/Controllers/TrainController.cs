using EndPoint.Site.Models.Dto.Train;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint.Site.Controllers
{
    public class TrainController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tickets(/*FilterTrainDto filter*/) {

            List <TicketDto> values = new List<TicketDto> ();
            return View(values);
        }
        public IActionResult Passenger( )
        {
            return View();
        }
    }
}
