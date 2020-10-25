using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations
{
  public class ClientConfiguration : IEntityTypeConfiguration<Client>
  {
    public void Configure(EntityTypeBuilder<Client> builder)
    {
      builder
        .HasKey(c => c.Id);

      builder
        .HasMany(p => p.Projects)
        .WithOne(c => c.Client)
        .HasForeignKey(c => c.IdClient)
        .OnDelete(DeleteBehavior.SetNull);
    }
  }
}
