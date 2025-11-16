using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace Ordermanagement.Infrastructure.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(nameof(Permission));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnName(nameof(Permission.Name));
        builder.Property(x => x.Description).HasColumnName(nameof(Permission.Description));
    }
}
