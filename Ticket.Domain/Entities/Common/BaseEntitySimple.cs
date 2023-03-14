namespace Ticket.Domain.Entities.Common
{
    public abstract class BaseEntitySimple<TKey>
    {
        public TKey Id { get; set; }

    }
    public abstract class BaseEntitySimple : BaseEntitySimple<long>
    {
    }
}
