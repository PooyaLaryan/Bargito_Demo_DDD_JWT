using Ordermanagement.Infrastructure.Persistence;
using Ordermanagement.Infrastructure.Repositories.Base;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.UserPermissions.Command;

namespace Ordermanagement.Infrastructure.Repositories.UserPermissions.Command;

public class UserPermissionCommandRepository(WriteDbContext writeDbContext) : CommandRepository<UserPermission>(writeDbContext), IUserPermissionCommandRepository;
