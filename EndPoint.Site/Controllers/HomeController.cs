using EndPoint.Site.Models;
using EndPoint.Site.Models.Dto;
using EndPoint.Site.Models.Dto.DomesticFlight;
using EndPoint.Site.Models.Dto.Home;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using Ticket.Common;
using Ticket.Common.Interfaces.FacadPatterns;
using Ticket.Domain.Entities.Users;
using Ticket.Infrastructure.Sms;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDomesticFlightFacad _domesticFlightFacad;
        private readonly ISmsPanel _smsPanel;
        public HomeController(ILogger<HomeController> logger, IDomesticFlightFacad domesticFlightFacad, ISmsPanel smsPanel)
        {
            _logger = logger;
            _domesticFlightFacad = domesticFlightFacad;
            _smsPanel = smsPanel;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<ResultShowDto<List<CitySelectDto>>> SelectCitiesDomesticFlight(string searchText)
        {
            var res = await _domesticFlightFacad.CityListDFService.Execute(
                new Ticket.Application.Services.References.DomesticFlight.Queries.RequestCityListDFDto()
                {
                    SearchText = searchText
                });

            return new ResultShowDto<List<CitySelectDto>>
            {
                IsSuccess = res.IsSuccess,
                Message = res.Message,
                TypeMessage = res.MessageType.ToString(),
                Data = res.Data.Select(s => new CitySelectDto()
                {
                    CityName = s.CistyName,
                    CityId = s.CityId,
                    StateName = s.StateName
                }).ToList()
            };

        }
        [HttpPost]
        public async Task<IActionResult> SearchDomesticFlightTravel(SearchTravelDFDto req)
        {
            var res = new ResultShowDto();
            res.IsSuccess = true;
            //var res= req;
            //var value = new SelectTicketDFDto()
            //{
            //    BabyPassengerCount = req.BabyPassengerCount,
            //    FromCity = req.FromCity,
            //    FromDate = req.FromDate,
            //    SeniorPassengerCount = req.SeniorPassengerCount,
            //    TeenagerPassnegerCount = req.TeenagerPassnegerCount,
            //    ToCity = req.ToCity
            //};
            //return RedirectToAction("Tickets", "DomesticFlight",value);
            try
            {
                //چک کردن ورودی
                if (req.SeniorPassengerCount <= 0)
                {
                    res.IsSuccess = false;
                    res.Message = "حداقل باید یک مسافر بزرگسال وجود داشته باشد";
                    return Json( res);
                }
                var fromD = req?.FromDate?.ToMiladi();
                var toD = req?.ToDate?.ToMiladi();
                if (fromD == null)
                {
                    res.IsSuccess = false;
                    res.Message = "لطفا تاریخ سفر را مشخص کنید";
                    return Json(res);
                }
                if (req.TravelType == 2)
                {
                    if (fromD == null)
                    {
                        res.IsSuccess = false;
                        res.Message = "لطفا تاریخ برگشت را مشخص کنید";
                        return Json(res );
                    }
                    if (req.FromDate?.ToMiladi() > req.ToDate?.ToMiladi())
                    {
                        res.IsSuccess = false;
                        res.Message = " تاریخ رفت باید بزرگتر از تاریخ برگشت باشد";
                        return Json(res);
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "خطای ناشناخته";
                return Json(res);
            }
            if (Request.Cookies.Any(c => c.Key == "DFRequest"))
                Response.Cookies.Delete("DFRequest");
            Response.Cookies.Append("DFRequest", JsonConvert.SerializeObject(req));
            return Json( res );
        }
        public IActionResult DomesticFlight()
        {
            return View();
        }
        public IActionResult InternationalFlight()
        {
            return View();
        }
        public IActionResult Train()
        {
            return View();
        }
        public IActionResult Bus()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}