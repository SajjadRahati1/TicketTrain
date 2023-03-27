using System.ComponentModel.DataAnnotations;

namespace Ticket.Domain.Enums
{
    public enum Gender
    {
        [Display(Name ="آقا")]
        Man,
        [Display(Name ="خانم")]
        Woman
    }
}
