using API.Entities;
using API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
  public class ApiContext : DbContext
  {
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ClientConfiguration());
      modelBuilder.ApplyConfiguration(new ProjectConfiguration());
    }

  }
}
