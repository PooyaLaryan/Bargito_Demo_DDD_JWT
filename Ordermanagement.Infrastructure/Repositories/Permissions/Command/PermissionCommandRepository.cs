using Ordermanagement.Infrastructure.Persistence;
using Ordermanagement.Infrastructure.Repositories.Base;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Permissions.Command;

namespace Ordermanagement.Infrastructure.Repositories.Permissions.Command;

public class PermissionCommandRepository(WriteDbContext writeDbContext) : CommandRepository<Permission>(writeDbContext), IPermissionCommandRepository
{

}
