using API.Entities;
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
      modelBuilder.Entity<Project>()
        .HasMany(p => p.Payments)
        .WithOne(p => p.Project)
        .HasForeignKey(p => p.IdProject)
        .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Client>()
        .HasMany(p => p.Projects)
        .WithOne(c => c.Client)
        .HasForeignKey(c => c.IdClient)
        .OnDelete(DeleteBehavior.Restrict);
    }

  }
}
