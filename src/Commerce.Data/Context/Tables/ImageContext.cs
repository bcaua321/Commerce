using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Context.Tables
{
    public static class ImageContext
    {
        public static void ImageTable(this ModelBuilder builder)
        {
            var userTable = builder.Entity<Image>();

            userTable.ToTable("Image");

            userTable.HasKey(prop => prop.Id);

            userTable.Property(prop => prop.Url)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("varchar(100)");

            userTable.HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
