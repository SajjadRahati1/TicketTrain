using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Services.Users.Commands;
using Ticket.Common.Dto;

namespace Ticket.Application.Interfaces.Services
{
    public interface IPublicService<TReq,TRes>
    {
         Task<ResultDto<TRes>> Execute(TReq request);
    }

    public interface IPublicService<TReq>
    {
        Task<ResultDto> Execute(TReq request);
    }
    public interface IPublicService
    {
        Task<ResultDto> Execute();
    }
}
