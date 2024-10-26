using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ticket.Application.Services.Email.Commands;
using Ticket.Common.Interfaces.FacadPatterns;
using Ticket.Domain.Entities.Users;
using Ticket.Application.Services;
using Ticket.Application.Services.References.DomesticFlight.Queries;
using EndPoint.Site.Models.Dto;
using Ticket.Common;
using EndPoint.Site.Models.Dto.DomesticFlight;
using Ticket.Application.Services.Passengers.Queries;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using EndPoint.Site.Models.Dto.Home;
using Ticket.Domain.Entities.Refrences.Flight;
using System.Security.Claims;
using Ticket.Domain.Entities.Financial.Discount;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Microsoft.IdentityModel.Tokens;

namespace EndPoint.Site.Controllers
{
    public class DomesticFlightController : Controller
    {
        private readonly IUserFacad _userFacad;
        private readonly IFinancialFacad _financialFacad;
        private readonly IDomesticFlightFacad _domesticFlightFacad;
        private readonly UserManager<User> _userManager;

        public DomesticFlightController(IUserFacad userFacad, IFinancialFacad financialFacad, IDomesticFlightFacad domesticFlightFacad, UserManager<User> userManager)
        {
            _userFacad = userFacad;
            _financialFacad = financialFacad;
            _domesticFlightFacad = domesticFlightFacad;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var value = Request.Cookies.FirstOrDefault(c => c.Key == "DFRequest");
            if (value.Value.IsNullOrEmpty())
                return View();

            var req = JsonConvert.DeserializeObject<SearchTravelDFDto>(value.Value);

            return View(req);
        }
        public IActionResult Confirm()
        {
            return View();
        }
        public IActionResult GoToPay()
        {
            return RedirectToAction("Index");
            //send-sms
            //496C7A5178692F2F442F6766696F4642394332696F775143433237794F58686A786A5A5A4B47586B79616B3D
        }
        [HttpGet]
        public async Task<IActionResult> Tickets(SelectTicketDFDto req)
        {

            var countPassenger = req.TeenagerPassnegerCount + req.SeniorPassengerCount + req.BabyPassengerCount;

            var res = await _domesticFlightFacad.SelectFilterDFService.Execute(new RequestSelectFilterDF()
            {
                CountPassenger = countPassenger,
                FromCityId = req.FromCity,
                FromDate = req.FromDate,
                ToCityId = req.ToCity

            });

            if (!res.IsSuccess)
            {
                return Json(new ResultShowDto { IsSuccess = false, Message = res.Message, TypeMessage = res.MessageType.ToString() });
            }
            return Json(new ResultShowDto<List<ResultSelectTickets>>
            {
                IsSuccess = true,
                Data = res.Data.Select(r => new ResultSelectTickets()
                {
                    AirCraft = r.AirCraft,
                    AirlineCode = r.AirlineCode,
                    AirLineId = r.AirLineId,
                    AirlineLogo = r.AirlineLogo,
                    AirlineName = r.AirlineName,
                    Class = r.Class,
                    ClassTypeID = r.ClassTypeID,
                    ClassTypeName = r.ClassTypeName,
                    Commission = r.Commission,
                    Description = r.Description,
                    Destination = r.Destination,
                    DestinationName = r.DestinationName,
                    DiscountId = r.DiscountId,
                    DiscountText = r.DiscountText,
                    DomesticFlightId = r.DomesticFlightId,
                    EndMovingDateTime = r.EndMovingDateTime,
                    EndMovingDateTimePersian = r.EndMovingDateTime.ToShamsi(),
                    FlightId = r.FlightId,
                    FlightNumber = r.FlightNumber,
                    GroupRefundRulesTitle = r.GroupRefundRulesTitle,
                    IsCharter = r.IsCharter,
                    IsRefundable = r.IsRefundable,
                    IsSelectableInRoundtrip = r.IsSelectableInRoundtrip,
                    MaxAllowdBaggage = r.MaxAllowdBaggage,
                    OriginId = r.OriginId,
                    OriginName = r.OriginName,
                    PriceAdult = r.PriceAdult,
                    PriceChild = r.PriceChild,
                    PriceTeenage = r.PriceTeenage,
                    ResultTicketRefundRules = r.ResultTicketRefundRules.Select(rt => new ResultTicketDFRefundRulesDto()
                    {
                        DeductibleAmount = rt.DeductibleAmount,
                        Description = rt.Description,
                        EndHour = rt.EndHour,
                        End_AfterIssuanceTicket = rt.End_AfterIssuanceTicket,
                        End_BeforeFlight = rt.End_BeforeFlight,
                        IsPercent = rt.IsPercent,
                        StartHour = rt.StartHour,
                        Start_AfterIssuanceTicket = rt.Start_AfterIssuanceTicket,
                        Start_BeforeFlight = rt.Start_BeforeFlight,
                        Title = rt.Title
                    }).ToList(),
                    Seat = r.Seat,
                    Stars = r.Stars,
                    StartMovingDateTime = r.StartMovingDateTime,
                    StartMovingDateTimePersian = r.StartMovingDateTime.ToShamsi(),
                    Status = r.Status,
                    StatusName = r.StatusName,
                    TerminalNumber = r.TerminalNumber
                }).ToList()
            });
        }
        [HttpGet]
        public async Task<IActionResult> SelectTicket(long id, long? id2 = null)
        {
            var res1 = await _domesticFlightFacad.DomesticFlightInfoService.Execute(new RequestDomesticFlightInfoService() { FlightId = id });
            if (!res1.IsSuccess)
                return View(new ResultShowDto<List<InfoTicket>>()
                {
                    IsSuccess = res1.IsSuccess,
                    Message = res1.Message,
                    TypeMessage = res1.MessageType.ToString()
                });

            var result = new List<InfoTicket>()
                {
                    new InfoTicket()
                    {
                        DomesticFlightId = res1.Data.DomesticFlightId,
                        FlightId = res1.Data.FlightId,
                        FlightNumber = res1.Data.FlightNumber,
                        AirCraft = res1.Data.AirCraft,
                        TerminalNumber = res1.Data.TerminalNumber,
                        AirlineCode = res1.Data.AirlineCode,
                        AirLineId = res1.Data.AirLineId,
                        AirlineLogo = res1.Data.AirlineLogo,
                        AirlineName = res1.Data.AirlineName,
                        EndMovingDateTime = res1.Data.EndMovingDateTime,
                        DiscountId = res1.Data.DiscountId,
                        DiscountText = res1.Data.DiscountText,
                        Class = res1.Data.Class,
                        ClassTypeID = res1.Data.ClassTypeID,
                        ClassTypeName = res1.Data.ClassTypeName,
                        Commission = res1.Data.Commission,
                        GroupRefundRulesTitle = res1.Data.GroupRefundRulesTitle,
                        Description = res1.Data.Description,
                        Destination = res1.Data.Destination,
                        DestinationName = res1.Data.DestinationName,
                        IsCharter = res1.Data.IsCharter,
                        IsRefundable = res1.Data.IsRefundable,
                        IsSelectableInRoundtrip= res1.Data.IsSelectableInRoundtrip,
                        StartMovingDateTime = res1.Data.StartMovingDateTime,
                        MaxAllowdBaggage = res1.Data.MaxAllowdBaggage,
                        OriginId= res1.Data.OriginId,
                        OriginName = res1.Data.OriginName,
                        PriceAdult = res1.Data.PriceAdult,
                        PriceChild = res1.Data.PriceChild,
                        PriceTeenage = res1.Data.PriceTeenage,
                        Status = res1.Data.Status,
                        StatusName = res1.Data.StatusName,
                        Seat = res1.Data.Seat,
                        Stars = res1.Data.Stars

                    }
            };
            if (id2 != null && id2 > 0)
            {
                var res2 = await _domesticFlightFacad.DomesticFlightInfoService.Execute(new RequestDomesticFlightInfoService() { FlightId = id });

                if (res2.IsSuccess)
                    return View(new ResultShowDto<List<InfoTicket>>()
                    {
                        IsSuccess = res2.IsSuccess,
                        Message = res2.Message,
                        TypeMessage = res2.MessageType.ToString()
                    });
                result.Add(new InfoTicket()
                {
                    DomesticFlightId = res2.Data.DomesticFlightId,
                    FlightId = res2.Data.FlightId,
                    FlightNumber = res2.Data.FlightNumber,
                    AirCraft = res2.Data.AirCraft,
                    TerminalNumber = res2.Data.TerminalNumber,
                    AirlineCode = res2.Data.AirlineCode,
                    AirLineId = res2.Data.AirLineId,
                    AirlineLogo = res2.Data.AirlineLogo,
                    AirlineName = res2.Data.AirlineName,
                    EndMovingDateTime = res2.Data.EndMovingDateTime,
                    DiscountId = res2.Data.DiscountId,
                    DiscountText = res2.Data.DiscountText,
                    Class = res2.Data.Class,
                    ClassTypeID = res2.Data.ClassTypeID,
                    ClassTypeName = res2.Data.ClassTypeName,
                    Commission = res2.Data.Commission,
                    GroupRefundRulesTitle = res2.Data.GroupRefundRulesTitle,
                    Description = res2.Data.Description,
                    Destination = res2.Data.Destination,
                    DestinationName = res2.Data.DestinationName,
                    IsCharter = res2.Data.IsCharter,
                    IsRefundable = res2.Data.IsRefundable,
                    IsSelectableInRoundtrip = res2.Data.IsSelectableInRoundtrip,
                    StartMovingDateTime = res2.Data.StartMovingDateTime,
                    MaxAllowdBaggage = res2.Data.MaxAllowdBaggage,
                    OriginId = res2.Data.OriginId,
                    OriginName = res2.Data.OriginName,
                    PriceAdult = res2.Data.PriceAdult,
                    PriceChild = res2.Data.PriceChild,
                    PriceTeenage = res2.Data.PriceTeenage,
                    Status = res2.Data.Status,
                    StatusName = res2.Data.StatusName,
                    Seat = res2.Data.Seat,
                    Stars = res2.Data.Stars

                });
            }
            return View(new ResultShowDto<List<InfoTicket>>()
            {
                IsSuccess = true,
                Data = result
            });
        }
        [Authorize]
        public async Task<IActionResult> AddTicketReservation(RequestAddTicketDFReserveDto req)
        {
            var user = await _userManager.GetUserAsync(User);
            var res = await _domesticFlightFacad.AddTicketDFReservationService.Execute(new RequestAddTicketDFReservationDto()
            {
                FlightId = req.FlightId,
                Passengers = req.Passengers,
                SendOtherInformationToEmail = req.SendOtherInformationToEmail,
                SendOtherInformationToPhoneNumber = req.SendOtherInformationToPhoneNumber,
                UserId = user.Id
            });
            if (!res.IsSuccess)
            {
                return Json(new ResultShowDto { IsSuccess = false, Message = res.Message, TypeMessage = res.MessageType.ToString() });
            }
            var r = res.Data;
            return Json(new ResultShowDto<ResultAddTicketDFReserveDto>
            {
                IsSuccess = true,
                Data = new ResultAddTicketDFReserveDto()
                {
                    OrderNumber = r.OrderNumber,
                    Passengers = r.Passengers.Select(p => new ResultAddTicketDfReservePassengerDto()
                    {
                        PassengerId = p.PassengerId,
                        TicketNumber = p.TicketNumber
                    }).ToList(),
                    TicketNumber = r.TicketNumber
                }
            });
        }

    }
}
