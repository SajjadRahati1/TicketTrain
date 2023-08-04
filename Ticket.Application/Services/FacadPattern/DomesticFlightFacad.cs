using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Services.References.DomesticFlight.Queries;
using Ticket.Application.Services.Users.Commands;
using Ticket.Common.Interfaces.FacadPatterns;

namespace Ticket.Application.Services.FacadPattern
{
    public class DomesticFlightFacad: IDomesticFlightFacad
    {
        private readonly IDbContext _context;
        private readonly IHostingEnvironment _environment;

        public DomesticFlightFacad(IDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        #region ICityListDFService
        private ICityListDFService _cityListDF;
        public ICityListDFService CityListDFService
        {
            get
            {
                return _cityListDF = _cityListDF ?? new CityListDF(_context);
            }
        }
        #endregion

    }
}
