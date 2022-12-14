using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Commerce.Data.Context.Tables
{
    public static class ProductContext
    {
        public static void ProductTable(this ModelBuilder builder)
        {
            var userTable = builder.Entity<Product>();

            userTable.ToTable("Product");

            userTable.HasKey(prop => prop.Id);

            userTable.Property(prop => prop.Title)
               .IsRequired()
               .HasColumnName("Title")
               .HasColumnType("varchar(100)");

            userTable.Property(prop => prop.Price)
               .IsRequired()
               .HasColumnName("Price")
               .HasColumnType("decimal(10, 2)");

            userTable.Property(prop => prop.Description)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(200)");

            userTable.Property(prop => prop.Rating)
                .IsRequired()
                .HasColumnName("Rating")
                .HasColumnType("float(6,3)");

            userTable.Property(prop => prop.Thumbnail)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Thumbnail")
                .HasColumnType("varchar(200)");

            userTable.Property(prop => prop.DiscountPercentage)
                .IsRequired()
                .HasColumnName("DiscountPercentage")
                .HasColumnType("decimal(10, 2)");

            userTable.Property(prop => prop.Stock)
                .IsRequired()
                .HasColumnName("Stock")
                .HasColumnType("int");

            userTable.Property(prop => prop.Brand)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Brand")
                .HasColumnType("varchar(200)");

            userTable.HasOne(x => x.Category)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
