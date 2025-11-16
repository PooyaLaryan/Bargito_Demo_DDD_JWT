using MediatR;
using Microsoft.AspNetCore.Http;
using Ordermanagement.Infrastructure.Services.Security;

namespace Ordermanagement.Infrastructure.Services.Behaviors;

public class PermissionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IHttpContextAccessor _http;

    public PermissionBehavior(IHttpContextAccessor http)
    {
        _http = http;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var httpContext = _http.HttpContext;
        if (httpContext == null)
            throw new UnauthorizedAccessException("No HttpContext available.");

        var user = httpContext.User;
        if (!user.Identity?.IsAuthenticated ?? true)
            throw new UnauthorizedAccessException("Unauthenticated user");

        var permAttr = request.GetType()
            .GetCustomAttributes(typeof(PermissionAttribute), true)
            .FirstOrDefault() as PermissionAttribute;

        if (permAttr == null)
            return await next();

        var requiredPermission = permAttr.Permission;

        var userPermissions = user.Claims
            .Where(c => c.Type == "permission")
            .Select(c => c.Value)
            .ToHashSet();

        if (!userPermissions.Contains(requiredPermission))
            throw new UnauthorizedAccessException($"Access denied. Missing permission: {requiredPermission}");

        return await next();
    }
}
