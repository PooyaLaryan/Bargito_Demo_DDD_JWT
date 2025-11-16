using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace Ordermanagement.Infrastructure.Configurations;

public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable(nameof(UserPermission));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).HasColumnName(nameof(UserPermission.UserId));
        builder.Property(x => x.PermissionId).HasColumnName(nameof(UserPermission.PermissionId));
    }
}
