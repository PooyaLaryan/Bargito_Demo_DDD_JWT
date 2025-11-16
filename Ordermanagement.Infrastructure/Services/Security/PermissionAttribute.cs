namespace Ordermanagement.Infrastructure.Services.Security;



[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class PermissionAttribute : Attribute
{
    public string Permission { get; }

    public PermissionAttribute(string permission)
    {
        Permission = permission;
    }
}
