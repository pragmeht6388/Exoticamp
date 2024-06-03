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


        private IDbContextTransaction _transaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

    

    

      


         

         

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                OrderTotal = 400,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                OrderTotal = 135,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                OrderTotal = 85,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
                OrderTotal = 245,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
                OrderTotal = 142,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
                OrderTotal = 40,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
                OrderTotal = 116,
                OrderPaid = true,
                OrderPlaced = DateTime.UtcNow,
                UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });

            modelBuilder.Entity<Message>()
                .Property(s => s.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{253C75D5-32AF-4DBF-AB63-1AF449BDE7BD}"),
                Code = "1",
                MessageContent = "{PropertyName} is required.",
                Language = "en",
                Type = Message.MessageType.Error
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{ED0CC6B6-11F4-4512-A441-625941917502}"),
                Code = "2",
                MessageContent = "{PropertyName} must not exceed {MaxLength} characters.",
                Language = "en",
                Type = Message.MessageType.Error
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{FAFE649A-3E2A-4153-8FD8-9DCD0B87E6D8}"),
                Code = "3",
                MessageContent = "An event with the same name and date already exists.",
                Language = "en",
                Type = Message.MessageType.Error
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
