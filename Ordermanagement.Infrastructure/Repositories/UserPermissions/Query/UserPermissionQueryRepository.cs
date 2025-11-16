using Ordermanagement.Infrastructure.Persistence;
using Ordermanagement.Infrastructure.Repositories.Base;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.UserPermissions.Query;

namespace Ordermanagement.Infrastructure.Repositories.UserPermissions.Query;

public class UserPermissionQueryRepository(ReadDbContext readDbContext) : QueryRepository<UserPermission>(readDbContext), IUserPermissionQueryRepository;
