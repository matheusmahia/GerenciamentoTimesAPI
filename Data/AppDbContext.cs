using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<TimeEsportivo> Times { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}