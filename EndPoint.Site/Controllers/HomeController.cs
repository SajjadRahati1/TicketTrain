using EndPoint.Site.Models;
using EndPoint.Site.Models.Dto;
using EndPoint.Site.Models.Dto.Home;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ticket.Common.Interfaces.FacadPatterns;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDomesticFlightFacad _domesticFlightFacad;
        public HomeController(ILogger<HomeController> logger, IDomesticFlightFacad domesticFlightFacad)
        {
            _logger = logger;
            _domesticFlightFacad = domesticFlightFacad;
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
                Data = res.Data.Select(s=>new CitySelectDto()
                {
                    CityName = s.CistyName,
                    CityId = s.CityId,
                    StateName = s.StateName
                }).ToList()
            };

        }
        [HttpPost]
        public async Task<JsonResult> SearchDomesticFlightTravel(SearchTravelDFDto req)
        {
            var res= req;
            return Json(new { res});
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