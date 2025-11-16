namespace OrderManagement.Domain.Entities;

public class UserPermission : Entity
{
    public Guid UserId { get; set; }
    public Guid PermissionId { get; set; }
}
