using Ticket.Application.Services.References.DomesticFlight.Queries;

namespace Ticket.Common.Interfaces.FacadPatterns
{
    public interface IDomesticFlightFacad
    {
        ICityListDFService CityListDFService { get; }
    }
}
