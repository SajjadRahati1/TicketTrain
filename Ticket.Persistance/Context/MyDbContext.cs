using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Domain.Entities.Train;
using Ticket.Domain.Entities.Ticket;
using Ticket.Domain.Entities.TrainRoute;
using Ticket.Domain.Entities.Users;
using Ticket.Domain.Entities.Common;

namespace Ticket.Persistance.Context
{
    public class MyDbContext:DbContext, IDbContext
    {
        public MyDbContext(DbContextOptions options):base(options){}

        #region Ticket
        public DbSet<Ticket.Domain.Entities.Ticket.Ticket> Tickets { get; set; }

        #endregion

        #region Trains
        public DbSet<Train> Trains { get; set; }
        public DbSet<SeatOrBed> SeatOrBeds { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Compartment> Compartments { get; set; }

        #endregion

        #region TrainRoute
        public DbSet<TrainRoute> TrainRoutes { get; set; }
        public DbSet<TrainStationConnect> TrainStationConnects { get; set; }
        public DbSet<RouteTrainStationConnect> RouteTrainStationConnects { get; set; }
        public DbSet<City> Cities { get; set; }
        #endregion

        #region Users
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

    }
}
