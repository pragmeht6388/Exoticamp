﻿using Exoticamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Exoticamp.Persistence.Configurations
{
    [ExcludeFromCodeCoverage]
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            //Not necessary if naming conventions are followed in model
            builder
                .HasKey(b => b.EventId);

            builder
                .Property(b => b.CreatedBy)
                .HasColumnType("varchar(450)");

            builder
                .Property(b => b.LastModifiedBy)
                .HasColumnType("varchar(450)");

            builder
                .Property(b => b.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(b => b.Price)
                //.HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(b => b.Capacity)
                //.HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(b => b.Description)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder
                .Property(b => b.ImageUrl)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(b => b.Highlights)
                //.HasColumnType("varchar(50)")
                .IsRequired();


            builder
                .Property(b => b.EventRules)
                //.HasColumnType("varchar(50)")
                .IsRequired();

            //Not necessary if relationship conventions are followed in model(Cascade is the default behaviour)
            //builder
            //    .HasOne(b => b.Category)
            //    .WithMany(b => b.Events)
            //    .HasForeignKey(b => b.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
