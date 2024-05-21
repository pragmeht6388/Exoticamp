using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCleanProject1.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MyCleanProject1.Persistence.Configurations
{
    [ExcludeFromCodeCoverage]
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Not necessary if naming conventions are followed in model
            builder
                .HasKey(b => b.CategoryId);

            builder
                .Property(b => b.CreatedBy)
                .HasColumnType("varchar(450)");

            builder
                .Property(b => b.LastModifiedBy)
                .HasColumnType("varchar(450)");

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
