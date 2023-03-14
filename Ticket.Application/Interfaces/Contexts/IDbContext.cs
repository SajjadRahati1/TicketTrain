using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Train;
using Ticket.Domain.Entities.TrainRoute;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Interfaces.Contexts
{
    public interface IDbContext
    {
        #region Entites
        #region Ticket
        DbSet<Ticket.Domain.Entities.Ticket.Ticket> Tickets { get; set; }

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
        #endregion

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
