using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Base;

namespace OrderManagement.Domain.Repositories.UserPermissions.Command;

public interface IUserPermissionCommandRepository : ICommandRepository<UserPermission>;
