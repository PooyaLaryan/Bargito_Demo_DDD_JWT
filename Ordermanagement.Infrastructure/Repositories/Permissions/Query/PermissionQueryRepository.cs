using Ordermanagement.Infrastructure.Persistence;
using Ordermanagement.Infrastructure.Repositories.Base;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Permissions.Query;

namespace Ordermanagement.Infrastructure.Repositories.Permissions.Query;

public class PermissionQueryRepository(ReadDbContext readDbContext) : QueryRepository<Permission>(readDbContext), IPermissionQueryRepository;
