using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.References.DomesticFlight.Queries
{
    public interface ICityListDFService : IPublicService<RequestCityListDFDto, List<ResultCityListDFDto>>
    {

    }
    public class CityListDF : ICityListDFService
    {
        private readonly IDbContext _context;

        public CityListDF(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResultCityListDFDto>>> Execute(RequestCityListDFDto request)
        {
            try
            {
                request.SearchText = request.SearchText.IsNullOrEmpty() ? null : request.SearchText;

                var result = await _context
                .Cities
                .Include(c => c.State)
                .Where(c => request.SearchText==null || c.Name.Contains(request.SearchText) || c.State.Name.Contains(request.SearchText))
                .Select(c => new ResultCityListDFDto()
                {
                    CityId = c.Id,
                    CistyName = c.Name,
                    StateName = c.State.Name
                }).ToListAsync();

                return new ResultDto<List<ResultCityListDFDto>>()
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultCityListDFDto>> ()
                {
                    IsSuccess = false,
                    Message = "شهری برای سفر یافت نشد"
                };
            }
        }
    }
  
  

    public class RequestCityListDFDto
    {
        public string SearchText { get; set; }
       
    }

    public class ResultCityListDFDto
    {
        public long CityId { get; set; }
        public string CistyName { get; set; }
        public string StateName { get; set; }
        public string Country { get; set; }
    }
}
