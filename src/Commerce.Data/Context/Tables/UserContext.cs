using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Context.Tables
{
    public static class UserContext
    {
        public static void UserTable(this ModelBuilder builder)
        {
            var userTable = builder.Entity<User>();

            userTable.ToTable("User");

            userTable.HasKey(prop => prop.Id);

            userTable.Property(prop => prop.Name)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("name")
               .HasColumnType("varchar(100)");

            userTable.Property(prop => prop.Email)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("email")
               .HasColumnType("varchar(100)");

            userTable.Property(prop => prop.Password)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("varchar(100)");
        }
    }
}
