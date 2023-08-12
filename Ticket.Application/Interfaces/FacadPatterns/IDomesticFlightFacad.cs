using Ticket.Application.Services.Passengers.Queries;
using Ticket.Application.Services.References.DomesticFlight.Queries;

namespace Ticket.Common.Interfaces.FacadPatterns
{
    public interface IDomesticFlightFacad
    {
        ICityListDFService CityListDFService { get; }
        IAddEditTicketDFService AddEditTicketDFService { get; }
        IAddTicketDFReservationService AddTicketDFReservationService { get; }
        IEditTicketDFReservationService EditTicketDFReservationService { get; }
        IDomesticFlightInfoService DomesticFlightInfoService { get; }
        ISelectFilterDFService SelectFilterDFService { get; }
        ISelectTicketDFService SelectTicketDFService { get; }
        ISelectTicketReservationDFService SelectTicketReservationDFService { get; }

    }
}
