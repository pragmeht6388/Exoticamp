using Exoticamp.Application.Contracts;
using Exoticamp.Domain.Common;
using Exoticamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using CampsiteDetailsEntity = Exoticamp.Domain.Entities.CampsiteDetails;


namespace Exoticamp.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }


        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<CampsiteDetailsEntity> CampsiteDetails { get; set; }
        public DbSet<ChatbotResponse> ChatbotResponses { get; set; }
        public DbSet<UserQuery> UserQueries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventActivities> EventActivities { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<GuestDetails> GuestDetails { get; set; }
        public DbSet<ManageAvailability> ManageAvailabilities { get; set; }
        public DbSet<Reviews>  Reviews { get; set; }

        public DbSet< ReviewReply>  ReviewReplies { get; set; }
        public DbSet<CampsiteActivities> CampsiteActivities { get; set; }
        public DbSet<Payment> Payments {  get; set; }
        public DbSet<Tent> Tents { get; set; }
        public DbSet<TentAvailability> TentAvailability { get; set; }
        public DbSet<BlockedDates> BlockedDates { get; set; }
        public DbSet<Glamping> Glamps { get; set; }



        private IDbContextTransaction _transaction;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to many Relationship mapping for Event and Activities
            //modelBuilder.Entity<Event>()
            //    .HasMany(e => e.Activities)
            //    .WithMany(e => e.Events)
            //    .UsingEntity<EventActivities>(
            //        l => l.HasOne<Activities>().WithMany().HasForeignKey(e => e.ActivityId),
            //        r => r.HasOne<Event>().WithMany().HasForeignKey(e => e.EventId));
            //// Many to many Relationship mapping for Event and Locations
            //modelBuilder.Entity<Event>()
            //    .HasMany(e => e.Locations)
            //    .WithMany(e => e.Events)
            //    .UsingEntity<EventLocation>(
            //        l => l.HasOne<Location>().WithMany().HasForeignKey(e => e.LocationId),
            //        r => r.HasOne<Event>().WithMany().HasForeignKey(e => e.EventId));


            base.OnModelCreating(modelBuilder);

            // Configuring the many-to-many relationship
            modelBuilder.Entity<EventActivities>()
                .HasKey(ea => ea.Id);

            modelBuilder.Entity<EventActivities>()
                .HasOne(ea => ea.Event)
                .WithMany(e => e.EventActivities)
                .HasForeignKey(ea => ea.EventId);

            modelBuilder.Entity<EventActivities>()
                .HasOne(ea => ea.Activity)
                .WithMany(a => a.EventActivities)
                .HasForeignKey(ea => ea.ActivityId);

            // Configuring the many-to-many relationship
            modelBuilder.Entity<EventLocation>()
                .HasKey(ea => ea.Id);

            modelBuilder.Entity<EventLocation>()
                .HasOne(ea => ea.Event)
                .WithMany(e => e.EventLocations)
                .HasForeignKey(ea => ea.EventId);

            modelBuilder.Entity<EventLocation>()
                .HasOne(ea => ea.Location)
                .WithMany(a => a.EventLocations)
                .HasForeignKey(ea => ea.LocationId);

            modelBuilder.Entity<Event>()
             .HasOne(e => e.Campsite)
             .WithMany()
             .HasForeignKey(e => e.CampsiteId)
             .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior

            modelBuilder.Entity<CampsiteActivities>()
            .HasKey(ca => new { ca.CampsiteId, ca.ActivityId });

            modelBuilder.Entity<CampsiteActivities>()
                .HasOne(ca => ca.CampsiteDetails)
                .WithMany(cd => cd.CampsiteActivities)
                .HasForeignKey(ca => ca.CampsiteId);

            modelBuilder.Entity<CampsiteActivities>()
                .HasOne(ca => ca.Activities)
                .WithMany(a => a.CampsiteActivities)
                .HasForeignKey(ca => ca.ActivityId);


            //    modelBuilder.Entity<Domain.Entities.CampsiteDetails>()
            //.HasOne(cd => cd.Activities)
            //.WithMany(a => a.Campsites)
            //.HasForeignKey(cd => cd.ActivitiesId)
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChangesAsync();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
