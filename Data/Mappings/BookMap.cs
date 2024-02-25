using Capi_Library_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capi_Library_Api.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book_Table");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Sinopsis)
                .HasColumnName("Sinopsis")
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(x => x.Pages)
                .HasColumnName("Pages")
                .HasColumnType("SMALLINT")
                .IsRequired();

            builder.Property(x => x.GeneralAud)
                .HasColumnName("GeneralAud")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasMany(x => x.Writers)
                .WithMany(x => x.Books)
                .UsingEntity<Dictionary<string, Object>>(
                    "BookWriter",
                    book => book.HasOne<Writer>()
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .HasConstraintName("FK_BookWriter_WriterId")
                        .OnDelete(DeleteBehavior.Cascade),
                    writer => writer.HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_BookWriter_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                );


            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Books)
                .UsingEntity<Dictionary<string, Object>>(
                    "BookCategory",
                    book => book.HasOne<Category>()
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_BookCategory_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade),
                    category => category.HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_BookCategory_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                 );


        }
    }
}
