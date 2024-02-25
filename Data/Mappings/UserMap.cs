using Capi_Library_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capi_Library_Api.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User_Table");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(x => x.Email, "IX_User_Email")
                .IsUnique();

            builder.HasIndex(x => x.Cpf, "IX_User_Cpf")
                .IsUnique();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasConstraintName("FK_User_Role");


            builder.HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<Address>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_User_Address");

            builder.HasMany(x => x.Phones)
                .WithOne(x => x.User)
                .HasConstraintName("FK_User_Phone");
        }
    }
}
