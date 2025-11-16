using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Base;

namespace OrderManagement.Domain.Repositories.UserPermissions.Query;

public interface IUserPermissionQueryRepository : IQueryRepository<UserPermission>;
