using Capi_Library_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capi_Library_Api.Data.Mappings
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rental_Table");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.GetDate)
                .HasColumnName("GetDate")
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.ReturnDate)
             .HasColumnName("ReturnDate")
             .HasColumnType("DATETIME")
             .IsRequired();

            builder.HasOne(x => x.Rentaluser)
                .WithOne(x => x.Rental)
                .HasForeignKey<Rental>(x => x.UserId)
                .HasConstraintName("FK_RentalUser");

            builder.HasOne(x => x.RentalBook)
                .WithOne(x => x.Rental)
                .HasForeignKey<Rental>(x => x.BookId)
                .HasConstraintName("FK_RentalBook");
        }
    }
}
