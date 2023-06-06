using FirstApiProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FirstApiProject.DAL.EFCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Car>cars { get; set; }
    public DbSet<Brand> brands { get; set; }
    public DbSet<Color> colors { get; set; }
}
