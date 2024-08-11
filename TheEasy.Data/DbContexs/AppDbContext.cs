using Microsoft.EntityFrameworkCore;
using TheEasy.Domain.Entities;

namespace TheEasy.Data.DbContexs;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<User> Users { get; set; }
}
