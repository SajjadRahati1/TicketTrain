using Microsoft.EntityFrameworkCore;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Domain.Entities.Users;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Financial.Discount;
using Ticket.Domain.Entities.Financial;
using Ticket.Domain.Entities.References;
using Ticket.Domain.Entities.Refrences.Bus.Ticket;
using Ticket.Domain.Entities.Refrences.Bus;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Ticket.Domain.Entities.Refrences.Flight.InternationalFlight;
using Ticket.Domain.Entities.Refrences.Flight;
using Ticket.Domain.Entities.Refrences.Train.Ticket;
using Ticket.Domain.Entities.Refrences.Train;
using Ticket.Domain.Entities.Refrences;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ticket.Persistance.Config.User;
using Ticket.Persistance.Config.Flight;
using Ticket.Persistance.Config.Flight.DomesticFlight;

namespace Ticket.Persistance.Context
{

    public class MyDbContext : IdentityDbContext<User, Role, long>, IDbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region Entites

        #region Common / عمومی

        public DbSet<Bank> Banks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<State> States { get; set; }

        #endregion

        #region Financial / مالی

        public DbSet<CartNumbers> CartNumbers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        #region Discount / تخفیف
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<UsedDiscount> UsedDiscounts { get; set; }
        #endregion

        #endregion

        #region References / منابع => نوع های مختلف از کارکرد ها

        public DbSet<RefrenceType> RefrenceTypes { get; set; }
        public DbSet<CompanyServiceProviders> CompanyServiceProviders { get; set; }

        #region Bus / بلیط اتوبوس

        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusTerminal> BusTerminals { get; set; }
        public DbSet<BusTravel> BusTravels { get; set; }
        public DbSet<BusTravelCompany> BusTravelCompanies { get; set; }
        public DbSet<BusType> BusTypes { get; set; }
        public DbSet<ServiceProviderBus> ServiceProviderBuses { get; set; }
        public DbSet<TypeServiceProviderBus> TypeServiceProviderBuses { get; set; }

        #region Ticket / بلیط

        public DbSet<TicketBus> TicketBuses { get; set; }
        public DbSet<TicketBusReservation> TicketBusReservations { get; set; }
        public DbSet<TicketBusReturned> TicketBusReturneds { get; set; }

        #endregion

        #endregion

        #region Flight / بلیط پرواز
        public DbSet<AirLine> AirLines { get; set; }
        public DbSet<AirLineCompany> AirLineCompanies { get; set; }
        public DbSet<AirLineContants> AirLineContants { get; set; }
        public DbSet<AirLineFinancial> AirLineFinancials { get; set; }

        public DbSet<AirPlane> AirPlanes { get; set; }
        public DbSet<AirPlaneType> AirPlaneTypes { get; set; }
        public DbSet<AirplaneTerminal> AirplaneTerminals { get; set; }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightCompany> FlightCompanies { get; set; }
        public DbSet<FlightTag> FlightTags { get; set; }
        public DbSet<FlightTicketRefundRules> FlightTicketRefundRules { get; set; }
        public DbSet<GroupFlightTicketRefundRules> GroupFlightTicketRefundRules { get; set; }

        public DbSet<ServiceProviderAirPlane> ServiceProviderAirPlanes { get; set; }
        public DbSet<TypeServiceProviderAirPlane> TypeServiceProviderAirPlanes { get; set; }

        #region Domestic flight / پرواز داخلی

        public DbSet<DomesticFlight> DomesticFlights { get; set; }
        public DbSet<TicketDomesticFlight> TicketDomesticFlights { get; set; }
        public DbSet<TicketDomesticFlightReservation> TicketDomesticFlightReservations { get; set; }
        public DbSet<TicketDomesticFlightReturned> TicketDomesticFlightReturneds { get; set; }

        #endregion

        #region International flight / پرواز خارجی

        public DbSet<InternationalFlight> InternationalFlights { get; set; }
        public DbSet<TicketInternationalFlight> TicketInternationalFlights { get; set; }
        public DbSet<TicketInternationalFlightReservation> TicketInternationalFlightReservations { get; set; }
        public DbSet<TicketInternationalFlightReturned> TicketInternationalFlightReturneds { get; set; }

        #endregion

        #endregion

        #region Train / بلیط قطار

        public DbSet<Compartment> Compartments { get; set; }

        public DbSet<TrainTicketRefundRules> TrainTicketRefundRules { get; set; }
        public DbSet<GroupTrainTicketRefundRules> GroupTrainTicketRefundRules { get; set; }

        public DbSet<RouteTrainStationConnect> RouteTrainStationConnects { get; set; }
        public DbSet<SeatOrBed> SeatOrBeds { get; set; }

        public DbSet<ServiceProviderTrain> ServiceProviderTrains { get; set; }
        public DbSet<TypeServiceProviderTrain> TypeServiceProviderTrains { get; set; }

        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<TrainStationConnect> TrainStationConnects { get; set; }

        public DbSet<TrainTravel> TrainTravels { get; set; }

        #region Ticket / بلیط
        public DbSet<TicketTrain> TicketTrains { get; set; }
        public DbSet<TicketTrainReservation> TicketTrainReservations { get; set; }
        public DbSet<TicketTrainReturned> TicketTrainReturneds { get; set; }
        #endregion

        #endregion
        #endregion

        #region Users / کاربران

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Person> People { get; set; }
        /*  public DbSet<Role> Roles { get; set; }
          public DbSet<User> Users { get; set; }*/

        #endregion

        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region اجباری
            builder.Entity<UsedDiscount>(ud =>
            {
                ud.HasOne(ud => ud.Transaction)
                .WithMany(t => t.Discounts)
                .HasForeignKey("FK_UsedDiscounts_Transactions_NoCacade")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<Flight>(fl =>
            {
                fl.HasOne(f => f.OriginTerminal)
                .WithMany()
                .HasForeignKey("FK_Flights_AirplaneTerminals_OriginTerminalId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<Flight>(fl =>
            {
                fl.HasOne(f => f.DestinationTerminal)
                .WithMany()
                .HasForeignKey("FK_Flights_AirplaneTerminals_DestinationTerminalId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<BusTravel>(fl =>
            {
                fl.HasOne(f => f.OriginTerminal)
                .WithMany()
                .HasForeignKey("FK_BusTravels_BusTerminals_OriginTerminalId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<BusTravel>(fl =>
            {
                fl.HasOne(f => f.DestinationTerminal)
                .WithMany()
                .HasForeignKey("FK_BusTravels_BusTerminals_DestinationTerminalId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TicketTrainReservation>(fl =>
            {
                fl.HasOne(f => f.TrainStationOrigin)
                .WithMany()
                .HasForeignKey("FK_TicketTrainReservations_TrainStations_TrainStationOriginId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TicketTrainReservation>(fl =>
            {
                fl.HasOne(f => f.TrainStationDestination)
                .WithMany()
                .HasForeignKey("FK_TicketTrainReservations_TrainStations_TrainStationDestinationId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TicketTrainReservation>(fl =>
            {
                fl.HasOne(f => f.Transaction)
                .WithMany()
                .HasForeignKey("FK_TicketTrainReservations_Transactions_TransactionId")
                .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<TrainStationConnect>(fl =>
            {
                fl.HasOne(f => f.TrainStationDestination)
                .WithMany()
                .HasForeignKey("FK_TrainStationConnects_TrainStations_TrainStationDestinationId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TrainStationConnect>(fl =>
            {
                fl.HasOne(f => f.TrainStationOrigin)
                .WithMany()
                .HasForeignKey("FK_TrainStationConnects_TrainStations_TrainStationOriginId")
                .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<TicketBusReservation>(fl =>
            {
                fl.HasOne(f => f.Supervisor)
                .WithMany(s => s.TicketBusReservations)
                .HasForeignKey("FK_TicketBusReservations_Passengers_SupervisorId")
                .OnDelete(DeleteBehavior.NoAction);

            });


            builder.Entity<TicketBusReservation>(fl =>
            {
                fl.HasOne(f => f.Transaction)
                .WithMany()
                .HasForeignKey("FK_TicketBusReservations_Transactions_TransactionId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TicketDomesticFlightReservation>(fl =>
            {
                fl.HasOne(f => f.Transaction)
                .WithMany()
                .HasForeignKey("FK_TicketDomesticFlightReservation_Transactions_TransactionId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TicketInternationalFlightReservation>(fl =>
            {
                fl.HasOne(f => f.Transaction)
                .WithMany()
                .HasForeignKey("FK_TicketInternationalFlightReservation_Transactions_TransactionId")
                .OnDelete(DeleteBehavior.NoAction);

            });


            builder.Entity<TicketDomesticFlight>(fl =>
            {
                fl.HasOne(f => f.Reservation)
                .WithMany(f => f.Tickets)
                .HasForeignKey("FK_TicketDomesticFlights_TicketDomesticFlightReservations_ReservationId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<TicketInternationalFlight>(fl =>
            {
                fl.HasOne(f => f.Reservation)
                .WithMany(f => f.Tickets)
                .HasForeignKey("FK_TicketInternationalFlights_TicketInternationalFlightReservations_ReservationId")
                .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<TicketTrain>(fl =>
            {
                fl.HasOne(f => f.SeatOrBed)
                .WithMany()
                .HasForeignKey("FK_TicketTrains_SeatOrBeds_SeatOrBedId")
                .OnDelete(DeleteBehavior.NoAction);

            });
            #endregion


            #region IdentityConfig
            builder.Entity<User>(b =>
            {
               
                b.Property(u => u.Email).IsRequired(false);

                // Indexes for "normalized" username and email, to allow efficient lookups
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

               

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256).IsRequired(false);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256).IsRequired(false);

               

                b.HasOne(a => a.Wallet)
                    .WithOne()
                    .HasForeignKey<Wallet>(c => c.UserId).OnDelete(DeleteBehavior.NoAction); ;
            });

            #endregion


            Config(builder);
            base.OnModelCreating(builder);
        }

        private static void Config(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new IdentityUserRoleConfig());
            builder.ApplyConfiguration(new PassengerConfig());


            builder.ApplyConfiguration(new AirLineCompanyConfig());
            builder.ApplyConfiguration(new AirLineConfig());
            builder.ApplyConfiguration(new AirLineContantsConfig());
            builder.ApplyConfiguration(new AirPlaneConfig());
            builder.ApplyConfiguration(new AirplaneTerminalConfig());
            builder.ApplyConfiguration(new AirPlaneTypeConfig());
            builder.ApplyConfiguration(new AirLineFinancialConfig());
            builder.ApplyConfiguration(new FlightConfig());
            builder.ApplyConfiguration(new FlightClassConfig());
            builder.ApplyConfiguration(new FlightClassTypeConfig());
            #region DFlight
            builder.ApplyConfiguration(new DomesticFlightConfig());
            builder.ApplyConfiguration(new TicketDomesticFlightReturnedConfig());
            builder.ApplyConfiguration(new TicketDomesticFlightReservationConfig());
            builder.ApplyConfiguration(new TicketDomesticFlightConfig());

            #endregion
        }
    }
}
