using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Domain.Entities.Common
{
    public abstract class BaseEntity<TKey> : BaseEntityNotId
    {
        public TKey Id { get; set; }
      
    }
    public abstract class BaseEntity : BaseEntity<long>
    {
    }
   
}
