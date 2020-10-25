using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations
{
  public class ProjectConfiguration : IEntityTypeConfiguration<Project>
  {
    public void Configure(EntityTypeBuilder<Project> builder)
    {
      builder
        .HasKey(p => p.Id);

      builder
        .HasMany(p => p.Payments)
        .WithOne(p => p.Project)
        .HasForeignKey(p => p.IdProject)
        .OnDelete(DeleteBehavior.SetNull);
    }
  }
}
