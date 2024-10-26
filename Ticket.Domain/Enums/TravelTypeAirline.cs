using System.ComponentModel.DataAnnotations;

namespace Ticket.Domain.Enums
{
    public enum TravelTypeAirline
    {
        [Display(Name ="رفت")]
        Go=1,
        [Display(Name ="بزگشت")]
        GoAndBack=2
    }
}
