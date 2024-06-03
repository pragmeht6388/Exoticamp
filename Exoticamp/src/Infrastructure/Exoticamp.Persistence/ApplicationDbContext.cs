using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts;
using Exoticamp.Domain.Entities;
using Exoticamp.Domain.Common;

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
        public DbSet<CampsiteDetails> CampsiteDetails { get; set; }
        public DbSet<ChatbotResponse> ChatbotResponses { get; set; }
        public DbSet<UserQuery> UserQueries { get; set; }
        public DbSet<Location> Locations { get; set; }


        private IDbContextTransaction _transaction;


       
     


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to many Relationship mapping
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Activities)
                .WithMany(e => e.Events)
                .UsingEntity<EventActivities>(
                    l => l.HasOne<Activities>().WithMany().HasForeignKey(e => e.ActivityId),
                    r => r.HasOne<Event>().WithMany().HasForeignKey(e => e.EventId));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //seed data, added through migrations
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });


            modelBuilder.Entity<ChatbotResponse>().HasData(new ChatbotResponse
            {
                Id = 1,
                Keyword = "Technical Issue",
                Response = null,
                ParentId = 0
            });

            modelBuilder.Entity<ChatbotResponse>().HasData(new ChatbotResponse
            {
                Id = 2,
                Keyword = "Account Issue",
                Response = null,
                ParentId = 1
            });

            modelBuilder.Entity<ChatbotResponse>().HasData(new ChatbotResponse
            {
                Id = 3,
                Keyword = "Cannot login",
                Response = "Please reset your password.",
                ParentId = 1
            });

            modelBuilder.Entity<ChatbotResponse>().HasData(new ChatbotResponse
            {
                Id = 4,
                Keyword = "Update email",
                Response = "You can update your email in the account settings.",
                ParentId = 2
            });
            modelBuilder.Entity<ChatbotResponse>().HasData(new ChatbotResponse
            {
                Id = 5,
                Keyword = "Forgot password",
                Response = "You can reset your password using the Forgot Password link.",
                ParentId = 2
            });

            modelBuilder.Entity<UserQuery>().HasData(new UserQuery
            {
                Id = Guid.Parse("{FAFE649A-3E2A-4153-8FD8-9DCD0B87E6D8}"),
                Email = "s@gmail.com",
                Response = null,
                IsDeleted = false,
                Query = "Is there any pickup service available for pune?"
            });




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
