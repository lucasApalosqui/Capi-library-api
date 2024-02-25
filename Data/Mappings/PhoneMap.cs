using Capi_Library_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capi_Library_Api.Data.Mappings
{
    public class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Phone_Table");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
