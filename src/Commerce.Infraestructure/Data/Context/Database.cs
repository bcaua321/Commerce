using Entities;
using Microsoft.EntityFrameworkCore;
public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
    }

    DbSet<User> Users { get; set; }
}