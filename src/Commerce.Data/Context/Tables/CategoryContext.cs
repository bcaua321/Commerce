using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Context.Tables
{
    public static class CategoryContext
    {
        public static void CategoryTable(this ModelBuilder builder)
        {
            var userTable = builder.Entity<Category>();

            userTable.ToTable("Category");

            userTable.HasKey(c => c.Id);

            userTable.Property(prop => prop.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("varchar(100)");

            userTable.HasMany(x => x.Product)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
