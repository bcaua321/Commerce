using Commerce.Data.Context.Tables;
using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Context;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ProductTable();
        modelBuilder.CategoryTable();
        modelBuilder.ImageTable();
    }
}