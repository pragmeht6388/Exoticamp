﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Campsite> Campsites { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<CampsiteDetails> CampsiteDetails { get; set; }

        private IDbContextTransaction _transaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
