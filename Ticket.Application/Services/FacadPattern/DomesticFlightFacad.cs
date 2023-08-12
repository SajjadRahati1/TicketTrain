using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Services.Passengers.Queries;
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


        #region IAddEditTicketDFService
        private IAddEditTicketDFService _addEditTicketDF;
        public IAddEditTicketDFService AddEditTicketDFService
        {
            get
            {
                return _addEditTicketDF = _addEditTicketDF ?? new AddEditTicketDFService(_context);
            }
        }
        #endregion

        #region IAddEditTicketDFService
        private IAddTicketDFReservationService _ddTicketDFReservation;
        public IAddTicketDFReservationService AddTicketDFReservationService
        {
            get
            {
                return _ddTicketDFReservation = _ddTicketDFReservation ?? new AddTicketDFReservationService(_context);
            }
        }
        #endregion

        #region IAddEditTicketDFService
        private IEditTicketDFReservationService _editTicketDFReservation;
        public IEditTicketDFReservationService EditTicketDFReservationService
        {
            get
            {
                return _editTicketDFReservation = _editTicketDFReservation ?? new EditTicketDFReservationService(_context);
            }
        }
        #endregion


        #region IDomesticFlightInfoService
        private IDomesticFlightInfoService _domesticFlightInfo;
        public IDomesticFlightInfoService DomesticFlightInfoService
        {
            get
            {
                return _domesticFlightInfo = _domesticFlightInfo ?? new DomesticFlightInfoService(_context);
            }
        }
        #endregion
      
        #region IDomesticFlightInfoService
        private ISelectFilterDFService _selectFilterDF;
        public ISelectFilterDFService SelectFilterDFService
        {
            get
            {
                return _selectFilterDF = _selectFilterDF ?? new SelectFilterDFService(_context);
            }
        }
        #endregion
      
        #region IDomesticFlightInfoService
        private ISelectTicketDFService _selectTicketDF;
        public ISelectTicketDFService SelectTicketDFService
        {
            get
            {
                return _selectTicketDF = _selectTicketDF ?? new SelectTicketDFService(_context);
            }
        }
        #endregion

        #region IDomesticFlightInfoService
        private ISelectTicketReservationDFService _selectTicketeservationDF;
        public ISelectTicketReservationDFService SelectTicketReservationDFService
        {
            get
            {
                return _selectTicketeservationDF = _selectTicketeservationDF ?? new SelectTicketReservationDFService(_context);
            }
        }
        #endregion
      

    }
}
